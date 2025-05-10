namespace RentalAppMVC.DTOs
{
    public class HouseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public int NumberOfRooms { get; set; }
        public bool HasGarage { get; set; }
        public bool HasBalcony { get; set; }
        public int Floors { get; set; }
    }
}

