using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Kategori adını giriniz.")]
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

        public string CategoryImage { get; set; } = string.Empty;
        public bool CategoryIsActive { get; set; }
    }
}
