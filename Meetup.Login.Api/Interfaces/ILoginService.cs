using Meetup.Login.Api.DTOs.UserDTOs;

namespace Meetup.Login.Api.Interfaces
{
    public interface ILoginService
    {
        Task<string> GetToken(LoginData data);
    }
}
