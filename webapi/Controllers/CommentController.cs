using ImageStorage.Api.Attributes;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateCommentModel model)
        {
            var jwtUser = (JwtUserModel)HttpContext.Items["jwtUserModel"];

            var result = await _commentService.CreateAndReturnCommentAsync(model, jwtUser);

            return new JsonResult(result);
        }
    }
}
