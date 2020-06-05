using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.DTO;
using RealEstate.BLL.Interfaces;
using RealEstate.ViewModels;

namespace RealEstate.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticateService _authService;
        private readonly IUserService _userService;

        public AccountController(IAuthenticateService authenticate, IUserService userService)
        {
            _authService = authenticate;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] UserViewModel login)
        {
            var user = await _userService.GetUser(login.Email, login.PasswordHash);
            var token = await _authService.Authenticate(user);
            if (token == "" || token == null)
            {
                return BadRequest("Invalid Request");
            }

            return Ok(new LoginResponse()
            {
                Token = token,
            });
        }
    }
}
