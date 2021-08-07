using System.ComponentModel.DataAnnotations;

namespace IntravisionTestTask.Models
{
    public class Session : BaseModel
    {
        [Required, Range(0, 1000)]
        public int DepositedMoney { get; set; } = 0;

        public string Token { get; set; }
    }
}