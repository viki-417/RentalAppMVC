namespace RentalAppMVC.DTOs
{
    public class StudioDTO : PropertyDTO
    {
        public int FloorNumber { get; set; }
        public bool HasElevator { get; set; }
        public bool Pets { get; set; }
        public bool Furnitured { get; set; }
        public bool AC { get; set; }
        public bool Balcony { get; set; }
        public bool Garage { get; set; }
        public bool Tv { get; set; }
        public bool Wifi { get; set; }

    }
}
