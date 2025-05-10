using RentalAppMVC.Data;

namespace RentalAppMVC.DTOs
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } 
        public string Address { get; set; } = string.Empty;
       public virtual string? Type { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public virtual UserDTO? User { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}