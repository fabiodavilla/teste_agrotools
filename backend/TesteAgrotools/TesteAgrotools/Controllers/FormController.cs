using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteAgrotools.DTO;
using TesteAgrotools.Entities;
using TesteAgrotools.Services;

namespace TesteAgrotools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private FormServices _service;

        public FormController(FormServices service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Form> result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Teste(int id)
        {
            Form result = _service.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] FullFormDTO form)
        {
            _service.Create(form);

            return Ok();
        }
    }
}
