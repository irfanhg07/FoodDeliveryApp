using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Restaurant
    {
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
        public List<Order> Orders { get; set; }
    }
}
