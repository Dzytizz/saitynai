using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using saitynai_server.Auth;
using saitynai_server.Auth.Model;
using saitynai_server.Data;
using static saitynai_server.Auth.Model.AuthDtos;

namespace saitynai_server.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(UserManager<User> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByNameAsync(registerUserDto.UserName);
            if (user != null)
                return BadRequest($"User already exists.");

            var newUser = new User
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            if (!createUserResult.Succeeded)
                return BadRequest($"Could not create user with error(s) `{createUserResult.Errors}.`");

            await _userManager.AddToRoleAsync(newUser, Roles.User);

            return CreatedAtAction(nameof(Register), new UserDto(newUser.Id, newUser.UserName, newUser.Email));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var user = await _userManager.FindByNameAsync(loginUserDto.UserName);
            if (user == null)
                return Unauthorized("Username and(or) password is invalid.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);
            if (!isPasswordValid)
                return Unauthorized("Username and(or) password is invalid.");

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);

            return Ok(new SuccessfulLoginDto(accessToken, roles));
        }
    }
}
