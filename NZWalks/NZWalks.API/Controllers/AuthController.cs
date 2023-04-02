using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        public AuthController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            // Validate the incoming data


            // Check if user authenticated 
            // Check userName and password
            var isAuthenticated = await userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);
            if (isAuthenticated)
            {
                // Generate a JWT token
            }
            return BadRequest("username or password is incorrect!");
        }
    }
}
