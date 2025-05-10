namespace RentalAppMVC.DTOs
{
    public class HouseDTO : PropertyDTO
    {
        public int NumberOfRooms { get; set; }
        public bool HasGarage { get; set; }
        public bool HasBalcony { get; set; }
        public int Floors { get; set; }
        public bool Pets { get; set; }
        public bool Furnitured { get; set; }
        public bool AC { get; set; }
        public bool Balcony { get; set; }
        public bool Garage { get; set; }
        public bool Tv { get; set; }
        public bool Wifi { get; set; }
    }
}

