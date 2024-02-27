using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.Response
{
    public class MenuItemResponse
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }

        // Additional properties if needed

        public MenuItemResponse(int itemId, string itemName, decimal price, int restaurantId)
        {
            ItemId = itemId;
            ItemName = itemName;
            Price = price;
            RestaurantId = restaurantId;
        }
    }
}
