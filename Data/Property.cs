namespace RentalAppMVC.Data
{
    public abstract class Property : BaseEntity
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public virtual string Type { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Property( string title, string description, string address, string type, string imageUrl, string userId)
        {
           
            Title = title;
            Description = description;
            Address = address;
            Type = type;
            ImageUrl = imageUrl;
            UserId = userId;
        }

        public virtual string GetPropertyDetails()
        {
            return $" Image: {ImageUrl}\n{Title} ({Type})\n{Description}\nPrice: {Price:C}\nAddress: {Address}";
        }
    }
}
