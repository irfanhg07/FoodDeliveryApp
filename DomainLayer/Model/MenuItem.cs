using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class MenuItem
    {
        public int ItemId { get; set; }

        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int RestaurantId { get; set; } // Foreign key

        // Navigation property
        public Restaurant Restaurant { get; set; }
    }
}
