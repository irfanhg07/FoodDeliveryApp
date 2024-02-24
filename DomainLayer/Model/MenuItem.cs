using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("RestaurantId")]
        public int RestaurantId { get; set; } // Foreign key

        // Navigation property
        [JsonIgnore]
        public Restaurant? Restaurant { get; set; }

        [JsonIgnore]
        public List<Order>? Orders { get; set; }
    }
}
