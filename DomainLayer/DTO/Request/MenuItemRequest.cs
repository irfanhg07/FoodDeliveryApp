﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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