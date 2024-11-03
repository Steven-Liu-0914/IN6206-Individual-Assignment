using Microsoft.AspNetCore.Mvc;

namespace WebAuthExamples.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiKeyAuthController : ControllerBase
    {
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            return Ok("You have accessed protected data using API Key Authentication.");
        }
    }
}
