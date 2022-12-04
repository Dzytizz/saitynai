using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Auth.Model
{
    public class AuthDtos
    {
        public record RegisterUserDto([Required] string UserName, [Required,EmailAddress] string Email, [Required] string Password);

        public record LoginUserDto(string UserName, string Password);

        public record UserDto(string Id, string UserName, string Email);

        public record SuccessfulLoginDto(string AccessToken, IList<string> Roles); // add refresh token here
    }
}
