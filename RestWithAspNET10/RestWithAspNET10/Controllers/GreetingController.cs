using Microsoft.AspNetCore.Mvc;
using RestWithAspNET10.Model;

namespace RestWithAspNET10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public Greeting Get()
        {
            var greeting = new Greeting
            {
                Id = 1,
                Content = "Hello World"
            };

            return greeting;
        }
    }
}
