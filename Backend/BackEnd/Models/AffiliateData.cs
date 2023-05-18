namespace BackEnd.Models
{
    public class AffiliateData
    {
        public int Id { get; set; } = 0;
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public string Product { get; set; }
        public decimal Value { get; set; }
        public string Seller { get; set; }
    }
}
