using Microsoft.AspNetCore.Mvc;
using WebAuthExamples.Handler;

[ApiController]
[Route("api/mfaAuth")]
public class MfaAuthController : ControllerBase
{
    private readonly MfaService _mfaService;

    public MfaAuthController(MfaService mfaService)
    {
        _mfaService = mfaService;
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        if (username == "testuser" && password == "testpassword") // Replace with real validation
        {
            // Generate OTP and store it in session (or cache for production)
            var otp = _mfaService.GenerateOtp();
            HttpContext.Session.SetString("Otp", otp);  // Store OTP for later validation

            // Simulate sending OTP (log or response)
            Console.WriteLine($"Generated OTP: {otp}");

            return Ok("Primary login successful. OTP has been sent to your registered contact.");
        }

        return Unauthorized("Invalid credentials");
    }

    [HttpPost("verify-otp")]
    public IActionResult VerifyOtp(string enteredOtp)
    {
        var storedOtp = HttpContext.Session.GetString("Otp");

        if (storedOtp == null)
        {
            return Unauthorized("OTP session expired. Please log in again.");
        }

        if (_mfaService.ValidateOtp(enteredOtp, storedOtp))
        {
            HttpContext.Session.SetString("MfaVerified", "true");  // Mark MFA as complete
            HttpContext.Session.Remove("Otp"); // Clear OTP after successful validation
            return Ok("MFA verified successfully. Access granted.");
        }

        return Unauthorized("Invalid OTP. Please try again.");
    }


    [HttpGet("secure-data")]
    public IActionResult GetSecureData()
    {
        var mfaVerified = HttpContext.Session.GetString("MfaVerified");
        if (mfaVerified != "true")
        {
            return Unauthorized("MFA required to access this resource.");
        }

        return Ok("You have accessed protected data using Multi-Factor Authentication.");
    }

}
