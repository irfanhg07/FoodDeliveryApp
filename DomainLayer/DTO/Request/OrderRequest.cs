using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.Request
{
    public class OrderRequest
    {
        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Restaurant ID is required.")]
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "At least one menu item is required.")]
        public int MenuItemId  { get; set; }
    }
}
