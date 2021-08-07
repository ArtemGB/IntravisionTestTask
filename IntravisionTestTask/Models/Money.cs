using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Models
{
    public class Money : BaseModel
    {
        [Required]
        public CoinType Type { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Sum { get; set; }
        public bool Enable { get; set; }
    }
}