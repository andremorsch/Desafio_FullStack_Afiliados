using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BackEnd.Services
{
    public class FileService
    {
        public static async Task<ResponseList<AffiliateData>?> ProcessFile(TextFile file, AffiliateDataContext context)
        {
            if (file.File != null)
            {
                using (var reader = new StreamReader(file.File.OpenReadStream()))
                {
                    string content = await reader.ReadToEndAsync();
                    ResponseList<AffiliateData> transactions = await ExtractTransactions(content, context);
                    return transactions;
                }
            }
            return null;
        }

        private static async Task<ResponseList<AffiliateData>> ExtractTransactions(
            string content, AffiliateDataContext context)
        {
            ResponseList<AffiliateData> response = new();

            string[] lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                AffiliateData transaction = new();

                try
                {
                    transaction.Type = int.Parse(line.Substring(0, 1));
                    transaction.Date = DateTime.ParseExact(line
                        .Substring(1, 25), "yyyy-MM-dd'T'HH:mm:ssK", CultureInfo.InvariantCulture);
                    transaction.Product = line.Substring(26, 30).Trim();
                    transaction.Value = decimal.Parse(line.Substring(56, 10)) / 100;
                    transaction.Seller = line.Trim().Substring(66).Trim();

                    await context.AffiliateData.AddAsync(transaction);
                    response.SuccessListResult.Add(transaction);
                    
                }
                catch (ArgumentOutOfRangeException)
                {
                    response.ErrorListResult.Add(transaction);
                    response.Success = Enumerators.EnumSuccess.PARCIAL_SUCCESS;
                    response.Message.Add("Erro na conversão da linha");
                }
                catch (DbUpdateException)
                {
                    response.ErrorListResult.Add(transaction);
                    response.Success = Enumerators.EnumSuccess.PARCIAL_SUCCESS;
                    response.Message.Add("Erro ao inserir no banco de dados");                 
                }
            }
            await context.SaveChangesAsync();

            return response;
        }
    }
}
