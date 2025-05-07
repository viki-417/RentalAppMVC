namespace RentalAppMVC.Data
{
    public class Studio : Property
    {
        public Studio(string title, string description, string address, string type, string imageUrl, string userId) 
            : base(title, description, address, type, imageUrl, userId)
        {
        }

        public override string Type => "Studio";
        public double SizeInSquareMeters { get; set; }


        public override string GetPropertyDetails()
        {
            return $"{base.GetPropertyDetails()}\nSize: {SizeInSquareMeters} sq. m.";
        }
    }
}
