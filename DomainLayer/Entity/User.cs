using DomainLayer.Entity.DomainLayer.Model;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace DomainLayer.Model
{
    public class User : AuditableEntity
    {
        [Key]
        public int UserId { get; set; }

       
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string UserName { get; set; }

        
        [RegularExpression(@"^[\d\s+-]{10,15}$", ErrorMessage = "Invalid phone number")]

        public string UserPhone { get; set; }

       
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string UserEmail { get; set; }

       
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [StringLength(1000, ErrorMessage = "Profile length can't exceed 1000 characters")]
        public string Profile { get; set; }
 
        public ICollection<UserAddress> UserAddresses { get; set; }

       
        public ICollection<Order>? Orders { get; set; }



    }
}
