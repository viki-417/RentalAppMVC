namespace RentalAppMVC.Data
{
    public abstract class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public virtual string Type { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual string GetPropertyDetails()
        {
            return $" Image: {ImageUrl}\n{Title} ({Type})\n{Description}\nPrice: {Price:C}\nAddress: {Address}";
        }
    }
}
