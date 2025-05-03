namespace RentalAppMVC.Data
{
    public class Houses : Property
    {
        public override string Type => "House";

        public int NumberOfRooms { get; set; }
        public bool HasGarage { get; set; }
        public bool HasBalcony { get; set; }
        public int Floors { get; set; }

        public override string GetPropertyDetails()
        {
            return $"{base.GetPropertyDetails()}\n{NumberOfRooms} Bedrooms, Garage: {(HasGarage ? "Yes" : "No")}" +
                $"\n Balcony: {(HasBalcony ? "Yes" : "No")}\n{Floors} Floors";
        }
    }
}
