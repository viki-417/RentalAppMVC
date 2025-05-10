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
                        Email = "user@example.com"
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
                        UserId = user.Id  // Assign UserId here
                    }
                );

                await context.SaveChangesAsync(); // Use SaveChangesAsync for async operations
            }
        }
    }
}
