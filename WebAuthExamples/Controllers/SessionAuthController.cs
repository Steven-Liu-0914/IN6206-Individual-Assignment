using Microsoft.AspNetCore.Mvc;

namespace WebAuthExamples.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionAuthController : ControllerBase
    {
        // Endpoint for logging in and creating a session
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            // Replace with your own authentication logic
            if (username == "testuser" && password == "testpassword")
            {
                // Store the username in session
                HttpContext.Session.SetString("User", username);
                return Ok("Login successful!");
            }

            return Unauthorized("Invalid credentials");
        }

        // Endpoint to log out and clear the session
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session data
            return Ok("You have been logged out.");
        }

        // Endpoint for accessing secure data
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            // Check if the user is logged in by checking the session
            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                return Unauthorized("You must be logged in to access this resource.");
            }

            return Ok($"Hello {user}, you have accessed protected data.");
        }


    }
}
