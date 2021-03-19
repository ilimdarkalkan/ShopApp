using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Please enter a value.")]
        [Display(Name = "Ürün Adı", Prompt = "Enter Product Name")]
        [StringLength(60,MinimumLength =4,ErrorMessage ="Product name must be between 4-60 characters.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter a value.")]
        public string Url { get; set; }


        [Required(ErrorMessage = "Please enter a value.")]
        [Range(1,1500000000,ErrorMessage ="Price must be at least 1")]
        public int? Price { get; set; }

        [StringLength(250, MinimumLength = 4, ErrorMessage = "Description must be between 4-250 characters.")]
        [Required(ErrorMessage = "Please enter a value.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please select a photo.")]
        public string ImageUrl { get; set; }


        public bool isApproved { get; set; }
        public bool isHome { get; set; }
        public List<Category> selectedCategories { get; set; }
    }
}
