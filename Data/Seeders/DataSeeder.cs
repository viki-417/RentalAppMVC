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

                var user = await userManager.FindByEmailAsync("user@example.com");
                if (user == null)
                {

                    user = new User
                    {
                        UserName = "user@example.com",
                        Email = "user@example.com",
                        ContactInformation = "0988764351",
                        Name = "Emil Draganov"

                    };
                    await userManager.CreateAsync(user, "Password123!"); 
                }


                context.Apartments.Add(
                    new Apartment()
                    {
                        Address = "123 Main St",
                        Description = "A cozy apartment in the city center.",
                        Price = 1200,
                        Title = "City Center Apartment",
                        FloorNumber = 5,
                        ImageUrl = "/images/apartment1.jpg",
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
                context.Apartments.Add(
    new Apartment()
    {
        Address = "12 Maple Street",
        Description = "Compact and affordable apartment, ideal for students.",
        Price = 600,
        Title = "Budget-Friendly Student Apartment",
        FloorNumber = 1,
        ImageUrl = "/images/apartment2.jpg",
        IsAvailable = true,
        HasElevator = false,
        Type = "Apartment",
        UserId = user.Id,
        Pets = false,
        Furnitured = true,
        AC = false,
        Balcony = false,
        Garage = false,
        Tv = false,
        Wifi = true
    });

                context.Apartments.Add(
                new Apartment()
                {
                     Address = "45 Green Hill Rd",
                     Description = "Spacious modern apartment with a beautiful park view.",
                     Price = 950,
                     Title = "Modern Apartment Near Park",
                     FloorNumber = 2,
                     ImageUrl = "/images/apartment3.jpg",
                     IsAvailable = true,
                     HasElevator = false,
                     Type = "Apartment",
                     UserId = user.Id,
                     Pets = true,
                     Furnitured = false,
                     AC = true,
                     Balcony = false,
                     Garage = true,
                     Tv = false,
                     Wifi = true
                });
                context.Apartments.Add(
                new Apartment()
                {
                    Address = "88 Sunset Blvd",
        Description = "Luxury top-floor apartment with sea view and premium amenities.",
        Price = 2500,
        Title = "Luxury Penthouse with Sea View",
        FloorNumber = 12,
        ImageUrl = "/images/apartment4.jpg",
        IsAvailable = true,
        HasElevator = true,
        Type = "Apartment",
        UserId = user.Id,
        Pets = true,
        Furnitured = true,
        AC = true,
        Balcony = true,
        Garage = true,
        Tv = true,
        Wifi = true
    });



                await context.SaveChangesAsync(); 
            }
        }
    }
}
