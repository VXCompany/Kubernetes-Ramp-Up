using Microsoft.AspNetCore.Mvc;

namespace hello_from_dotnet.Controllers
{
    [ApiController]
    [Route("/")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello from .NET 5";
        }
    }
}
