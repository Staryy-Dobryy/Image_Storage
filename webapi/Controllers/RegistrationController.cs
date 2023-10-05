using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        IWebHostEnvironment _appEnvironment;

        public RegistrationController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(string userName, string email, string password)
        {
            return new JsonResult("Some JWT text");
        }
    }
}
