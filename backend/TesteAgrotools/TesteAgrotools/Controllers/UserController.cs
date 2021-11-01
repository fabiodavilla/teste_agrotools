using Microsoft.AspNetCore.Mvc;
using TesteAgrotools.Entities;
using TesteAgrotools.Services;

namespace TesteAgrotools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserServices _service;

        public UserController(UserServices service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] User user)
        {
            bool result = _service.Login(user);

            return Ok(result);
        }
    }
}
