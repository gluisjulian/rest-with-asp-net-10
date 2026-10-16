using Microsoft.AspNetCore.Mvc;
using RestWithAspNET10.Model;
using RestWithAspNET10.Services;

namespace RestWithAspNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly ILogger _logger;

        public BookController(IBookService service, ILogger<BookController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            _logger.LogInformation("Fetching all books");
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            _logger.LogInformation("Fetching book with ID {id}", id);
            var book = _service.FindById(id);
            if (book == null)
            {
                _logger.LogInformation("Book with ID {id} not found", id);
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _logger.LogInformation("Create Book: {title}", book.Title);
            var createdBook = _service.Create(book);
            if (createdBook == null)
            {
                _logger.LogInformation("Failed to create book with name {title}", book.Title);
                return NotFound();
            }

            return Ok(createdBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            _logger.LogInformation("Updating Book with ID: {id}", book.Id);
            var createdBook = _service.Update(book);
            if (createdBook == null)
            {
                _logger.LogError("Failed to update book with ID {id}", book.Id);
                return NotFound();
            }
            _logger.LogDebug("Book Updated Successfully: {title}", book.Title);
            return Ok(createdBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Delete Book with ID: {id}", id);
            var book = _service.FindById(id);
            if (book == null) return NotFound();
            _service.Delete(id);

            _logger.LogDebug("Book with ID {id} deleted successfully", id);
            return NoContent();
        }
    }
}
