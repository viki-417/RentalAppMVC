namespace RentalAppMVC.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}