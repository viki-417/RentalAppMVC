using RentalAppMVC.Data;

namespace RentalAppMVC.DTOs
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public virtual string Type { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public virtual UserDTO? User { get; set; }
    }
}
