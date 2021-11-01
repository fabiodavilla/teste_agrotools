using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteAgrotools.DTO;
using TesteAgrotools.Entities;
using TesteAgrotools.Services;

namespace TesteAgrotools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private AnswerServices _service;

        public AnswerController(AnswerServices service)
        {
            _service = service;
        }

        [HttpGet("form/{id}")]
        public IActionResult GetAnswerByIdForm(int id)
        {
            List<Answer> result = _service.GetAnswerByIdForm(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] FormAnswerDTO form)
        {
            _service.Create(form);

            return Ok();
        }
    }
}
