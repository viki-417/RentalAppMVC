namespace RentalAppMVC.Data
{
    public class Studio : Property
    {
        public override string Type => "Studio";
        public double SizeInSquareMeters { get; set; }

        public int FloorNumber { get; set; }
        public bool HasElevator { get; set; }

        public override string GetPropertyDetails()
        {
            return $"{base.GetPropertyDetails()}\nSize: {SizeInSquareMeters}\nFloor {{FloorNumber}}, Elevator: {{(HasElevator ? \"Yes\" : \"No\") sq. m.";
        }
    }
}
