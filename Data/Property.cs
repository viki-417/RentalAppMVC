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

        public bool Pets { get; set; } = true;
        
        public bool Furnitured { get; set; }
        public bool AC { get; set; }
        public bool Balcony { get; set; }
        public bool Garage { get; set; }
        public bool Tv { get; set; }
        public bool Wifi { get; set; }

        public virtual string GetPropertyDetails()
        {
            return $" Image: {ImageUrl}\n{Title} ({Type})\n{Description}\nPrice: {Price:C}\nAddress: {Address}\nPets: {Pets}";
        }
    }
}
