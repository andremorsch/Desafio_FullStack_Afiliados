using BackEnd.Models;
using System.Globalization;

namespace BackEnd.Services
{
    public class FileService
    {
        public static async Task<List<Transaction>?> ProcessFile(TextFile file)
        {
            if (file.File != null)
            {
                using (var reader = new StreamReader(file.File.OpenReadStream()))
                {
                    string content = await reader.ReadToEndAsync();
                    List<Transaction> transactions = ExtractTransactions(content);
                    return transactions;
                }
            }
            return null;
        }
    }
}
