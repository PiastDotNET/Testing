using Microsoft.AspNetCore.Mvc;

namespace Piast.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : Controller
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}