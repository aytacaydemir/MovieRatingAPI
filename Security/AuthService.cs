using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using MovieRatingAPI.Models;
using MovieRatingAPI.Services.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieRatingAPI.Security
{
    public class AuthService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _userService = userService;
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims, 
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<User> AuthenticateUser(User user) 
        {
            var _user = await _userService.FindUserByName(user.Username);

            if ( _user==null || user.Password != _user.Password )
            {
                return null;
            }
            return _user;
        }
        public Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string? scheme)
        {
            throw new NotImplementedException();
        }
        public Task ChallengeAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }
        public Task ForbidAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }
        public Task SignInAsync(HttpContext context, string? scheme, ClaimsPrincipal principal, AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }
        public Task SignOutAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }
    }
}
