using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/oauth")]
public class OAuthController : ControllerBase
{
    // Endpoint to initiate the Google OAuth login
    [HttpGet("login")]
    public IActionResult Login()
    {
        var redirectUrl = Url.Action("GoogleResponse", "OAuth");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, "Google");
    }

    // Endpoint to handle the OAuth response
    [HttpGet("google-response")]
    public IActionResult GoogleResponse()
    {
        var result = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;

        if (result?.Principal != null)
        {
            var claims = result.Principal.Identities
                .FirstOrDefault()?.Claims.Select(claim => new
                {
                    claim.Type,
                    claim.Value
                });

            return Ok(new { Message = "OAuth login successful", Claims = claims });
        }

        return Unauthorized("Google login failed.");
    }

    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [HttpGet("secure-data")]
    public IActionResult SecureData()
    {
        return Ok("You have accessed protected data using Google OAuth.");
    }
}
