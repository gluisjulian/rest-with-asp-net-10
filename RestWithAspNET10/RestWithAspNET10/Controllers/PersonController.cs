using Microsoft.AspNetCore.Mvc;
using RestWithAspNET10.Model;
using RestWithAspNET10.Services;

namespace RestWithAspNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _services;

        public PersonController(IPersonServices services)
        {
            _services = services;
        }


        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_services.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _services.FindById(id);
            if(person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var createdPerson = _services.Create(person);
            if (createdPerson == null) return NotFound();
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var createdPerson = _services.Update(person);
            if (createdPerson == null) return NotFound();
            return Ok(createdPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _services.FindById(id);
            if (person == null) return NotFound();

            _services.Delete(id);
            return NoContent();
        }
    }
}
