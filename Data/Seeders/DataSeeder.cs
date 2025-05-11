using Humanizer;
using Microsoft.AspNetCore.Identity;

namespace RentalAppMVC.Data.Seeders
{
    public static class DataSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            if (context.Apartments.Count() == 0)
            {
                // Find or create a user to assign the apartment to
                var user = await userManager.FindByEmailAsync("user@example.com");
                if (user == null)
                {
                    // If the user doesn't exist, create one (or handle this as needed)
                    user = new User
                    {
                        UserName = "user@example.com",
                        Email = "user@example.com",
                        ContactInformation = "0988764351",
                        Name = "Emil Draganov"

                    };
                    await userManager.CreateAsync(user, "Password123!"); // Add password as needed
                }

                // Add the apartment with the UserId
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
                        UserId = user.Id,
                        Pets = false,
                        Furnitured = true,
                        AC = false,
                        Balcony = true,
                        Garage = false,
                        Tv = true,
                        Wifi = true
                    });
                context.Studios.Add(
                 new Studio()
                 {
                     Address = "456 Oak Avenue",
                     Description = "Spacious apartment near the park.",
                     Price = 2950,
                     Title = "Parkside Apartment",
                     FloorNumber = 2,
                     ImageUrl = "/images/studiot1.jpg",
                     IsAvailable = true,
                     HasElevator = false,
                     Type = "Studio",
                     UserId = user.Id,
                     Pets = true,
                     Furnitured = false,
                     AC = true,
                     Balcony = true,
                     Garage = false,
                     Tv = true,
                     Wifi = false
                 });

                context.Studios.Add(
                 new Studio()
                 {
                     Address = "789 Elm Street",
                     Description = "Modern apartment with all amenities.",
                     Price = 1350,
                     Title = "Modern Living",
                     FloorNumber = 7,
                     ImageUrl = "https://example.com/image3.jpg",
                     IsAvailable = true,
                     HasElevator = true,
                     Type = "Studio",
                     UserId = user.Id,
                     Pets = false,
                     Furnitured = true,
                     AC = true,
                     Balcony = true,
                     Garage = true,
                     Tv = true,
                     Wifi = true
                 });



                await context.SaveChangesAsync(); // Use SaveChangesAsync for async operations
            }
        }
    }
}
