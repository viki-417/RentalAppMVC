namespace RentalAppMVC.Data
{
    public class Studio : Property
    {
        public override string Type => "Studio";
        public double SizeInSquareMeters { get; set; }


        public override string GetPropertyDetails()
        {
            return $"{base.GetPropertyDetails()}\nSize: {SizeInSquareMeters} sq. m.";
        }
    }
}
