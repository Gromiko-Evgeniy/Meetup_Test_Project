using Meetup.Login.Domain.Entities;

namespace Meetup.Login.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> AuthenticateUser(string email, string password);
        Task<List<User>> RegisterUser(User user);
        Task<List<User>> DeleteUser(int id);
        Task<User> EditUser(User user);
    }
}
