using BackEnd.Enumerators;

namespace BackEnd.Models
{
    public class ResponseList<TResult>
    {
        public string Success { get; set; } = EnumSuccess.TOTAL_SUCCESS.ToString();
        public List<string> Message { get; set; } = new();
        public List<TResult> SuccessListResult { get; set; } = new();
        public List<string> ErrorListResult { get; set; } = new();

    }
}
