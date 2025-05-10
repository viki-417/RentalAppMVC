namespace RentalAppMVC.DTOs
{
    public class HouseDTO : PropertyDTO
    {
        public int NumberOfRooms { get; set; }
        public bool HasGarage { get; set; }
        public bool HasBalcony { get; set; }
        public int Floors { get; set; }
    }
}

