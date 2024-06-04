using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TestingJWT_OAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoogleController : ControllerBase
    {

        [EnableCors("AllowAll")]
        [HttpGet("loginWithGoogle")]
            public async Task Login()
            {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri= Url.Action("GoogleResponse")
            });
        }
        [EnableCors("AllowAll")]
        [HttpGet("signin-google")]
        public async Task<IActionResult> GoogleResponse()
        {
            
            var response = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (response.Principal == null) return BadRequest();
            var claims = response.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value



            });

            var name = response.Principal.FindFirstValue(ClaimTypes.Name);
            var givenName = response.Principal.FindFirstValue(ClaimTypes.GivenName);
            var email = response.Principal.FindFirstValue(ClaimTypes.Email);


            return Ok(email); ;
        }

       
    }
}
       
        
    

