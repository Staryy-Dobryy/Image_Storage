using ImageStorage.Api.Attributes;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.BLL.Services.Realization;
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
        public async Task<IActionResult> Get(string? userId)
        {
            List<PreviewModel>? result;

            var jwtUser = (JwtUserModel)HttpContext.Items["jwtUserModel"];

            if (userId is null)
            {
                result = await _publicationService.GetUserGalleryAsync(jwtUser);

                return new JsonResult(result);
            }
            Guid userGuid = Guid.Parse(userId);

            result = await _publicationService.GetUserPublicGalleryAsync(userGuid);

            return new JsonResult(result);
        }
    }
}
