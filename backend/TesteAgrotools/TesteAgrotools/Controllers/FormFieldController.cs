using Microsoft.AspNetCore.Mvc;
using TesteAgrotools.Services;

namespace TesteAgrotools.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormFieldController : ControllerBase
    {
        private FormFieldServices _service;

        public FormFieldController(FormFieldServices service)
        {
            _service = service;
        }

        [HttpGet("Teste")]
        public IActionResult Teste()
        {
            return Ok("teste");
        }
    }
}
