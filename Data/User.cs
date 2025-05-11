using Microsoft.AspNetCore.Identity;

namespace RentalAppMVC.Data
{
    public class User : IdentityUser
    {
        public required string Name { get; set; }
        public required string ContactInformation{ get; set; }
      
        public virtual ICollection<Property>? OfferedProperties { get; set; }
    }
}
