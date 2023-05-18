using BackEnd.Models;
using System.Globalization;

namespace BackEnd.Services
{
    public class FileService
    {
        public static async Task<List<AffiliateData>?> ProcessFile(TextFile file)
        {
            if (file.File != null)
            {
                using (var reader = new StreamReader(file.File.OpenReadStream()))
                {
                    string content = await reader.ReadToEndAsync();
                    List<AffiliateData> transactions = ExtractTransactions(content);
                    return transactions;
                }
            }
            return null;
        }

        private static List<Transaction> ExtractTransactions(string content)
        {
            List<Transaction> transactions = new();

            string[] lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                Transaction transaction = new();
                string[] separetaBySpace = line.Split("  ");
                transaction.Type = separetaBySpace[0].Substring(0, 1);
                transaction.Date = DateTime.ParseExact(separetaBySpace[0]
                    .Substring(1, 25), "yyyy-MM-dd'T'HH:mm:ssK", CultureInfo.InvariantCulture);
                transaction.Product = separetaBySpace[0].Substring(26).Trim();
                transaction.Value = decimal.Parse(separetaBySpace.Last().Trim().Substring(0, 10)) / 100;
                transaction.Seller = separetaBySpace.Last().Trim().Substring(10).Trim();

                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}
