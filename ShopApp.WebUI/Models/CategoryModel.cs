using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please enter a value.")]
        [StringLength(50,MinimumLength =5,ErrorMessage = "Category must be between 4-60 characters.")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Url must be between 4-60 characters.")]
        [Required(ErrorMessage = "Please enter a value.")]
        public string Url { get; set; }
        public List<Product> Products { get; set; }
    }
}
