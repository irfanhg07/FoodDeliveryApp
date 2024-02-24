using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DomainLayer.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        // Foreign key navigation property
        [ForeignKey("UserId")]
        [JsonIgnore]
        public User? User { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal OrderTotal { get; set; }
        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }
     
        [Required]
        public DateTime OrderDate { get; set; }
        // Foreign key
        public int RestaurantId { get; set; }
        // Navigation property
        [Required]
        [JsonIgnore]
        public Restaurant? Restaurant { get; set; }
        [JsonIgnore]
        public List<MenuItem>? MenuItems { get; set; }
    }

    
}
