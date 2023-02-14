
using Meetup.Login.Api.Entities;

namespace Meetup.Login.Api.Data
{
    public static class DbInitializer
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Users.Any()) {
                var adminUser = new User()
                {
                    Email = "admin@gmail.com",
                    Password = "admin1234",
                    Name = "Evgeny",
                    Role = Role.Admin,
                };

                var Ivan = new User()
                {
                    Email = "ivan@gmail.com",
                    Password = "ivan1234",
                    Name = "Ivan",
                    Role = Role.User,
                };

                var Max = new User()
                {
                    Email = "max@gmail.com",
                    Password = "max1234",
                    Name = "Max",
                    Role = Role.User,
                };

                context.Users.AddRange(new User[] { adminUser, Ivan, Max });
                await context.SaveChangesAsync();

            }
        }
    }
}
