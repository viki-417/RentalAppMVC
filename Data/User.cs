using Microsoft.AspNetCore.Identity;

namespace RentalAppMVC.Data
{
    public class User : IdentityUser
    {
        public virtual ICollection<Property>? OfferedProperties { get; set; }
    }
}
