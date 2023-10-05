using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleAuthController : ControllerBase
    {
        private readonly IGoogleAuthService _googleAuthService;

        public GoogleAuthController(IGoogleAuthService googleAuthService)
        {
            _googleAuthService = googleAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GoogleAuthModel model)
        {
            if (ModelState.IsValid)
            {
                string jwt = await _googleAuthService.LoginByGoogleAccountAsync(model);
                return new JsonResult(jwt);
            }

            return BadRequest(ModelState);
        }
    }
}
