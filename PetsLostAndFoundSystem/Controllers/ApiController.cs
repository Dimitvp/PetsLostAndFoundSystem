using Microsoft.AspNetCore.Mvc;

namespace PetsLostAndFoundSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : Controller
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";
    }
}
