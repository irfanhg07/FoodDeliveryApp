using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.Responses
{
    public class RestaurantResponse
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }

        // Additional properties if needed

        public RestaurantResponse(int restaurantId, string name, string address, string phone, string description)
        {
            RestaurantId = restaurantId;
            Name = name;
            Address = address;
            Phone = phone;
            Description = description;
        }
    }
}

