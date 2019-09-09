using Microsoft.AspNetCore.Mvc;

namespace IndentityServerTest.AuthServer.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok("Auth Server");
        }
    }
}