using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Models.UpdateModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task UpdateUserInfoAsync(UpdateUserModel source, JwtUserModel jwtUser, string webRootPath = null);
        Task<UserModel?> GetUserProfileByIdAsync(Guid userId);
        Task SaveUserImageAsync(IFormFile image, string webRootPath, string imageUrl);
    }
}
