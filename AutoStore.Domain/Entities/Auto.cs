using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoStore.Domain.Entities
{
    public class Auto
    {
        [HiddenInput(DisplayValue=false)]
        public int AutoId { get; set; }


        [Display(Name="Name of auto")]
        [Required(ErrorMessage ="Please, write a name of car")]
        public string Name { get; set; }
        
        
        [Display(Name ="Country of made")]
        [Required(ErrorMessage ="Please, write a country")]
        public string Country { get; set; }


        [Display(Name ="Category")]
        [Required(ErrorMessage ="Please, write a category of car")]
        public string Category { get; set; }

        [Required(ErrorMessage ="Please, write a price")]
        [Range(0.01,double.MaxValue,ErrorMessage ="Please, write a positive value for price")]
        [Display(Name = "Price (₽)")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
