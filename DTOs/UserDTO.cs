namespace RentalAppMVC.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public required string Name { get; set; }
        public required string ContactInformation { get; set; }
       
    }
}