using Humanizer;
using Microsoft.AspNetCore.Identity;

namespace RentalAppMVC.Data.Seeders
{
    public static class DataSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Apartments.Count() == 0)
            {
                context.Apartments.Add(
                    new Apartment()
                    {
                        Address = "123 Main St",
                        Description = "A cozy apartment in the city center.",
                        Price = 1200,
                        Title = "City Center Apartment",
                        FloorNumber = 5,
                        ImageUrl = "https://example.com/image1.jpg",
                        IsAvailable = true,
                        HasElevator = true,
                        Type = "Apartment",
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
