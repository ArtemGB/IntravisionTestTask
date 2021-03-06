using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntravisionTestTask.Models
{
    public class Product : BaseModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public uint ProductCount { get; set; }
        public string ProductImg { get; set; }
        
    }
}
