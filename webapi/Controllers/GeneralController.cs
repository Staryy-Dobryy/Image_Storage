using ImageStorage.Api.Attributes;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneralController : ControllerBase
    {
        private readonly IPublicationService _publicationService;

        public GeneralController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {

            var popularPreviews = await _publicationService.GetPublicationsPreviews(3, 0);
            var interestingPreviews = await _publicationService.GetPublicationsPreviews(12, 3);

            var result = new
            {
                popular = popularPreviews,
                interesting = interestingPreviews
            };

            return new JsonResult(result);
        }
    }
}
