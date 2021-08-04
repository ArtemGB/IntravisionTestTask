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
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        [Required]
        public uint Quantity { get; set; }
        
    }
}
