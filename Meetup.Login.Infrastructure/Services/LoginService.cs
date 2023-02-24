using System.IdentityModel.Tokens.Jwt;
using Meetup.Common;
using System.Security.Claims;
using Meetup.Login.Domain.DTOs.UserDTOs;
using Meetup.Login.Domain.Entities;
using Meetup.Login.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using AutoMapper;

namespace Meetup.Login.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository repository;
        private IOptions<AuthOptions> authOptions;
        private IMapper mapper;

        public LoginService(IUserRepository repository, IOptions<AuthOptions> authOptions, IMapper mapper)
        {
            this.repository = repository;
            this.authOptions = authOptions;
            this.mapper = mapper;
        }

        public async Task<ResponseInfo<string>> GetToken(LoginData data)
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

            return new ResponseInfo<string>( new JwtSecurityTokenHandler().WriteToken(jwt), true, "token");
        }

        public async Task<ResponseInfo<List<User>>> GetAllUsers() =>
            new ResponseInfo<List<User>>(await repository.GetAllUsers(), true, "all users");

        public async Task<ResponseInfo<User>> GetUserById(int id)
        {
            var user = await repository.GetUserById(id);
            if(user is null) return new ResponseInfo<User>(null, true, "user not found");

            return new ResponseInfo<User>(user, true, $"user with id {user.Id}");
        } 
            

        public async Task<ResponseInfo<List<User>>> RegisterUser(AddUserDto userDto)
        {
            if (userDto is null) return new ResponseInfo<List<User>>(null, false, "wrong request data");
            var newUser = mapper.Map<User>(userDto);

            var users = await repository.RegisterUser(newUser);

            return new ResponseInfo<List<User>>(users, true, "all users");
        }

        public async Task<ResponseInfo<List<User>>> DeleteUser(int id)
        {
            var users = await repository.DeleteUser(id);
            if (users is null) return new ResponseInfo<List<User>>(null, false, "user not found");
             
            return new ResponseInfo<List<User>>(users, true, "all users");
        }

        public async Task<ResponseInfo<User>> UpdateUser(UpdateUserDto userDto)
        {
            if (userDto == null) return new ResponseInfo<User>(null, false, "wrong request data");
            var newUser = mapper.Map<User>(userDto);

            var response = await repository.EditUser(newUser);
            if (response is null) return new ResponseInfo<User>(null, false, "event not found");

            return new ResponseInfo<User>(response, true, $"user with id {response.Id}");
        }
    }
}
