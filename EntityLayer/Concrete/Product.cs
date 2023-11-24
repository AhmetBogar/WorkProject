using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImage { get; set; }
        public bool ProductIsActive { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; } 
    }
}
