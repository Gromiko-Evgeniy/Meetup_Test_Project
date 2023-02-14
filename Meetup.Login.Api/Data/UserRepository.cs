using Meetup.Login.Api.Entities;
using Meetup.Login.Api.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Meetup.Login.Api.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext context;

        public UserRepository(DataContext context) {
            this.context = context;
        }

        public async Task<User> AuthenticateUser(string email, string password) =>
            await context.Users.FirstOrDefaultAsync(p => (p.Email == email) && (p.Password == password));

        public async Task<List<User>> GetAllUsers() =>
            await context.Users.ToListAsync();


        public async Task<User> GetUserById(int id) =>
            await context.Users.FirstOrDefaultAsync(p => p.Id == id);
    }
}
