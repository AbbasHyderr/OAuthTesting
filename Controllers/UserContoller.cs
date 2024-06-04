using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestingJWT_OAuth.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserContoller : ControllerBase
    {
        
            [HttpGet]
            public IActionResult Get()
            {
                return Ok("Hi Abbas");
            }

        
        
    }


}
