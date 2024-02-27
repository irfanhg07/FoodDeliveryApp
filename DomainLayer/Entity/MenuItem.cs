using DomainLayer.Entity;
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

      
        [StringLength(255)]

        public string ItemName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("RestaurantId")]
        public int RestaurantId { get; set; } // Foreign key


        public bool IsDeleted { get; set; } 


        // Navigation property
        [JsonIgnore]
        public Restaurant? Restaurant { get; set; }


        public List<OrderDetails> OrderDetails { get; set; }

    }
}
