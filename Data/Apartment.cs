namespace RentalAppMVC.Data
{
    public class Apartment : Property
    {
        public Apartment(string title, string description, string address, string type, string imageUrl, string userId) 
            : base(title, description, address, type, imageUrl, userId)
        {
        }

        public int FloorNumber { get; set; }
        public bool HasElevator { get; set; }


        public override string GetPropertyDetails()
        {
            return $"{base.GetPropertyDetails()}\nFloor {FloorNumber}, Elevator: {(HasElevator ? "Yes" : "No")}";
        }
    }
}
