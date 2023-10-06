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
    public class GalleryController : ControllerBase
    {
        private readonly IPublicationService _publicationService;

        public GalleryController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var jwtUser = (JwtUserModel)HttpContext.Items["jwtUserModel"];

            var result = await _publicationService.GetUserGalleryAsync(jwtUser);

            return new JsonResult(result);
        }
    }
}
