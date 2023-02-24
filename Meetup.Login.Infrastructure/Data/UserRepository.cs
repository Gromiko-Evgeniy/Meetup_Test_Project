using Meetup.Login.Domain.Entities;
using Meetup.Login.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Meetup.Login.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext context;

        public UserRepository(DataContext context) {
            this.context = context;
        }

        public async Task<User> AuthenticateUser(string email, string password) =>
            await context.Users.AsNoTracking().FirstOrDefaultAsync(p => (p.Email == email) && (p.Password == password));

        public async Task<List<User>> GetAllUsers() =>
            await context.Users.AsNoTracking().ToListAsync();


        public async Task<User> GetUserById(int id) =>
            await context.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<User>> RegisterUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return await GetAllUsers();
        }

        public async Task<List<User>> DeleteUser(int id)
        {
            var user = await GetUserById(id);
            if (user is null) return null;

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return await GetAllUsers();
        }

        public async Task<User> EditUser(User newUser)
        {
            var prevUser = await GetUserById(newUser.Id);
            if (prevUser is null) return null;

            prevUser.Name = newUser.Name;
            prevUser.Email = newUser.Email;
            prevUser.Password = newUser.Password;

            await context.SaveChangesAsync();

            return newUser;
        }
    }
}
