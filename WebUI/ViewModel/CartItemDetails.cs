using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModel
{
    public class CartItemDetails
    {

        [Required]
        public int CartID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
