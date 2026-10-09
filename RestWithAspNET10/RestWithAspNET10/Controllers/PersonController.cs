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
        private readonly ILogger _logger;

        public PersonController(IPersonServices services, ILogger<PersonController> logger)
        {
            _services = services;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult FindAll()
        {
            _logger.LogInformation("Fetching all persons");
            return Ok(_services.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            _logger.LogInformation("Fetching person with ID {id}", id);
            var person = _services.FindById(id);
            if (person == null) 
            {
                _logger.LogInformation("Person with ID {id} not found", id);
                return NotFound();
            } 

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation("Create Person: {firstName}", person.FirstName);
            var createdPerson = _services.Create(person);
            if (createdPerson == null)
            {
                _logger.LogInformation("Failed to create person with name {firstName}", person.FirstName);
                return NotFound();
            }

            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            _logger.LogInformation("Updating Person with ID: {id}", person.Id);
            var createdPerson = _services.Update(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to update person with ID {id}", person.Id);
                return NotFound();
            }
            _logger.LogDebug("Person Updated Successfully: {firstName}", person.FirstName);
            return Ok(createdPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Delete Person with ID: {id}", id);
            var person = _services.FindById(id);
            if (person == null) return NotFound();
            _services.Delete(id);

            _logger.LogDebug("Person with ID {id} deleted successfully", id);
            return NoContent();
        }
    }
}
