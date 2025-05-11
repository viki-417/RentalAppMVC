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

            var user = await userManager.FindByEmailAsync("user1@example.com");
            if (user == null)
            {

                user = new User
                {
                    UserName = "user1@example.com",
                    Email = "user1@example.com",
                    ContactInformation = "0988764351",
                    Name = "Emil Draganov"

                };
                await userManager.CreateAsync(user, "Password123!");
            }

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
                        UserId = user.Id,
                        Pets = false,
                        Furnitured = true,
                        AC = false,
                        Balcony = true,
                        Garage = false,
                        Tv = true,
                        Wifi = true
                    });


            }

                context.Studios.Add(
                new Studio()
                {
                    Address = "1010 Maple Blvd",
                    Description = "Compact and affordable studio-style apartment.",
                    Price = 700,
                    Title = "Compact Studio",
                    FloorNumber = 1,
                    ImageUrl = "/images/studiot3.jpg",
                    IsAvailable = false,
                    HasElevator = false,
                    Type = "Studio",
                    UserId = user.Id,
                    Pets = false,
                    Furnitured = false,
                    AC = false,
                    Balcony = false,
                    Garage = false,
                    Tv = false,
                    Wifi = false
                });


                context.Studios.Add(
                new Studio()
                {
                    Address = "212 Riverbank Rd",
                    Description = "Luxury apartment with river views.",
                    Price = 2200,
                    Title = "Riverside Luxury",
                    FloorNumber = 10,
                    ImageUrl = "/images/studiot4.jpg",
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

                context.Studios.Add(
                new Studio()
                {
                    Address = "212 Riverbank Rd",
                    Description = "Luxury apartment with river views.",
                    Price = 2200,
                    Title = "Riverside Luxury",
                    FloorNumber = 10,
                    ImageUrl = "/images/studiot4.jpg",
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
                if (!context.Houses.Any())
                { 
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
                    context.Houses.Add(
                    new House()
                    {
                        Address = "789 Greenfield Dr",
                        Description = "Spacious family home with a large backyard.",
                        Price = 1800,
                        Title = "Suburban Family House",
                        NumberOfRooms = 5,
                        ImageUrl = "/images/house1.jfif",
                        IsAvailable = true,
                        Type = "House",
                        UserId = user.Id,
                        Pets = true,
                        Furnitured = false,
                        AC = true,
                        Balcony = false,
                        Garage = true,
                        Tv = true,
                        Wifi = true
                    });
                    context.Houses.Add(
                  new House()
                  {
                      Address = "156 Country Lane",
                      Description = "Peaceful countryside home perfect for a weekend getaway.",
                      Price = 950,
                      Title = "Countryside Retreat",
                      NumberOfRooms = 3,
                      ImageUrl = "/images/house2.jpg",
                      IsAvailable = true,
                      Type = "House",
                      UserId = user.Id,
                      Pets = true,
                      Furnitured = true,
                      AC = false,
                      Balcony = true,
                      Garage = false,
                      Tv = false,
                      Wifi = false
                  });
                    context.Houses.Add(
                 new House()
                 {

                     Address = "88 Vista View Rd",
                     Description = "Elegant villa with panoramic hilltop views.",
                     Price = 3000,
                     Title = "Luxury Hilltop Villa",
                     NumberOfRooms = 7,
                     ImageUrl = "/images/house3.jpg",
                     IsAvailable = true,
                     Type = "House",
                     UserId = user.Id,
                     Pets = false,
                     Furnitured = true,
                     AC = true,
                     Balcony = true,
                     Garage = true,
                     Tv = true,
                     Wifi = true
                 });
                    await context.SaveChangesAsync();
                }
                if (context.Studios.Count() == 0)
                {
                 context.Studios.Add(
                 new Studio()
                 {
                     Address = "789 Elm Street",
                     Description = "Modern apartment with all amenities.",
                     Price = 1350,
                     Title = "Modern Living",
                     FloorNumber = 7,
                     ImageUrl = "/images/studiot2.jpg",
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

                }
            
        }
    }
}
