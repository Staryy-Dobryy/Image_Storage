using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicationController : ControllerBase
    {
        IWebHostEnvironment _appEnvironment;

        public PublicationController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile image, string description)
        {
            if (image != null)
            {
                // путь к папке Files
                string path = "/Images/" + image.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

            }

            return Ok();
        }
    }
}
