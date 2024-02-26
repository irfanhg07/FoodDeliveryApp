using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

       
        [StringLength(50)] 
        public string State { get; set; }

        
        [StringLength(50)] 
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

      
        [StringLength(100)]
        public string Street { get; set; }

       
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid Pincode")]
        public string Pincode { get; set; }


        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
