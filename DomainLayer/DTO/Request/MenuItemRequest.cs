using System.ComponentModel.DataAnnotations;
namespace DomainLayer.DTO.Request
{
    public class MenuItemRequest
    {
        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int RestaurantId { get; set; }
    }
}