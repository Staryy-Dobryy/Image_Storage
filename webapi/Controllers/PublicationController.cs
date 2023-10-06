using ImageStorage.Api.Attributes;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationController : ControllerBase
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IPublicationService _publicationService;

        public PublicationController(IWebHostEnvironment appEnvironment, IPublicationService publicationService)
        {
            _appEnvironment = appEnvironment;
            _publicationService = publicationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string publicationId)
        {
            var result = await _publicationService.GetPublicationById(Guid.Parse(publicationId));

            return new JsonResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(IFormFile image, string description, bool isPublic)
        {
            var jwtUser = (JwtUserModel)HttpContext.Items["jwtUserModel"];

            if (image is null)
            {
                return BadRequest();
            }

            CreatePublicationModel source = new()
            {
                Id = Guid.NewGuid(),
                Description = description,
                IsPublic = isPublic
            };
            source.ImageUrl = "/Images/" + source.Id + ".png";

            var result = await _publicationService.CreateAndReturnPublicationAsync(source, jwtUser, image, _appEnvironment.WebRootPath);

            return new JsonResult(result);
        }
    }
}
