using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntravisionTestTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
        [Required]
        public uint Quantity { get; set; }
        public string ImageSrc { get; set; }
        
    }
}
