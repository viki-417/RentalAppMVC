namespace RentalAppMVC.Data
{
    public class Apartment : Property
    {
        public override string Type => "Apartment";

        public int FloorNumber { get; set; }
        public bool HasElevator { get; set; }


        public override string GetPropertyDetails()
        {
            return $"{base.GetPropertyDetails()}\nFloor {FloorNumber}, Elevator: {(HasElevator ? "Yes" : "No")}";
        }
    }
}
