

using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DTO.Requests
{
    public class RestaurantRequest
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        //Comment
    }
}

