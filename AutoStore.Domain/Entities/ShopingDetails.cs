using System.ComponentModel.DataAnnotations;

namespace AutoStore.Domain.Entities
{
    public class ShopingDetails
    {
        [Required(ErrorMessage = "Write yor Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Write your Address")]
        [Display(Name="First Address")]
        public string Address1 { get; set; }
        [Display(Name = "Second Address")]
        public string Address2 { get; set; }
        [Display(Name = "Third Address")]
        public string Address3 { get; set; }
        [Required(ErrorMessage = "Write your city")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Write country")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
