using Meetup.Login.Api.Entities;

namespace Meetup.Login.Api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> AuthenticateUser(string email, string password);
    }
}
