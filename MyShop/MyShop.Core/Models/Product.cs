﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Product : BaseClass
    {
        
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 1000, ErrorMessage = "Price must be between $1 and $1000")]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        
    }
}
