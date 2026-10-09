using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestLogsController : ControllerBase
    {
        private readonly ILogger _logger;

        public TestLogsController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
