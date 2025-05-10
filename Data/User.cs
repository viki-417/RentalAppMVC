using Microsoft.AspNetCore.Identity;

namespace RentalAppMVC.Data
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Property>? OfferedProperties { get; set; }
    }
}
