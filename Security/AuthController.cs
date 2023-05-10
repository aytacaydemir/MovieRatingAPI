using Microsoft.AspNetCore.Mvc;
using MovieRatingAPI.DTOs.Requests;
using MovieRatingAPI.Models;

namespace MovieRatingAPI.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService= authService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            User user = new User
            {
                Username = request.Username,
                Password = request.Password
            };

            var _user = _authService.AuthenticateUser(user).Result;
            if (_user != null)
            {
                var token = _authService.GenerateToken(_user);
                return Ok(new {token});
            }
            return Unauthorized();
        }
    }
}
