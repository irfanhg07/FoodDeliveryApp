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
    public class Restaurant


    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        // Navigation property
        [JsonIgnore]
        public List<Order>? Orders { get; set; }
        [JsonIgnore]
        public List<MenuItem>? MenuItems { get; set; }
    }
}
