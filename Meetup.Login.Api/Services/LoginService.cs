using System.IdentityModel.Tokens.Jwt;
using Meetup.Auth.Common;
using System.Security.Claims;
using Meetup.Login.Api.DTOs.UserDTOs;
using Meetup.Login.Api.Entities;
using Meetup.Login.Api.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace Meetup.Login.Api.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository repository;
        private IOptions<AuthOptions> authOptions;

        public LoginService(IUserRepository repository, IOptions<AuthOptions> authOptions)
        {
            this.repository = repository;
            this.authOptions = authOptions;
        }
        public async Task<string> GetToken(LoginData data)
        {
            User user = await repository.AuthenticateUser(data.Email, data.Password);
            if (user is null) return null;

            var authParams = authOptions.Value;

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("role", user.Role.ToString())
            };

            var jwt = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(authParams.TokenLifeTime)),
                signingCredentials: new SigningCredentials(
                    authParams.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
