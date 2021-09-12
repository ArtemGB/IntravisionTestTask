using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Models
{
    public class Money : BaseModel
    {
        [Required]
        public CoinType CoinPar { get; set; }
        [Required]
        public int CoinCount { get; set; }
        public int CoinMaxCount { get; set; }
    }
}