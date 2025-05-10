using Microsoft.AspNetCore.Identity;

namespace RentalAppMVC.Data
{
    public class User : IdentityUser
    { 
        public string FullName { get; set; }

        public string ContactNumber { get; set; }
        public virtual ICollection<Property>? OfferedProperties { get; set; }
    }
}
