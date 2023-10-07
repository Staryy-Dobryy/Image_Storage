using ImageStorage.Api.Attributes;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Models.UpdateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.BLL.Services.Realization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IUserService _userService;
        public ProfileController(IUserService userService, IWebHostEnvironment appEnvironment)
        {
            _userService = userService;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? userId)
        {
            UserModel? result;

            var jwtUser = (JwtUserModel)HttpContext.Items["jwtUserModel"];

            if (userId is null)
            {
                result = await _userService.GetUserProfileByIdAsync(jwtUser.Id);

                return new JsonResult(result);
            }

            Guid userGuid = Guid.Parse(userId);

            result = await _userService.GetUserProfileByIdAsync(userGuid);

            return new JsonResult(result);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(IFormFile image, string newName)
        {

            var jwtUser = (JwtUserModel)HttpContext.Items["jwtUserModel"];

            Guid imageId = Guid.NewGuid();
            string imageUrl = "/Images/" + imageId + ".png";

            UpdateUserModel source = new()
            {
                Name = newName,
                ImageUrl = imageUrl
            };

            await _userService.SaveUserImageAsync(image, _appEnvironment.WebRootPath, imageUrl);
            await _userService.UpdateUserInfoAsync(source, jwtUser);

            return new JsonResult(source);
        }
    }
}
