using Meetup.Common;
using Meetup.Login.Domain.DTOs.UserDTOs;
using Meetup.Login.Domain.Entities;

namespace Meetup.Login.Application.Interfaces
{
    public interface ILoginService
    {
        Task<ResponseInfo<string>> GetToken(LoginData data);
        Task<ResponseInfo<List<User>>> GetAllUsers();
        Task<ResponseInfo<User>> GetUserById(int id);
        Task<ResponseInfo<List<User>>> RegisterUser(AddUserDto user);
        Task<ResponseInfo<List<User>>> DeleteUser(int id);
        Task<ResponseInfo<User>> UpdateUser(UpdateUserDto user);
    }
}
