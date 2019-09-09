using IndentityServerTest.BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IndentityServerTest.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private UserRepository _users;

        public HomeController(UserRepository users)
        {
            _users = users;
        }

        [Authorize]
        [HttpGet("secure")]
        public IActionResult Secured(int id)
        {
            return Ok(HttpContext.User.Claims.ToArray());
        }

        [HttpGet("unsecured")]
        public IActionResult Unsecured(int id)
        {
            return Ok();
        }
    }
}