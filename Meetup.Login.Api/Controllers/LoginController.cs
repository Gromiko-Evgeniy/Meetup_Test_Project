using Meetup.Login.Api.DTOs.UserDTOs;
using Meetup.Login.Api.Interfaces;
using Meetup.Login.Api.Services;
using Microsoft.AspNetCore.Mvc;


namespace Meetup.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService service;
        public LoginController(ILoginService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginData data)
        {
            var token = await service.GetToken(data);

            if (token is null) return Unauthorized();

            return Ok(new { access_token = token });
        }
    }
}
