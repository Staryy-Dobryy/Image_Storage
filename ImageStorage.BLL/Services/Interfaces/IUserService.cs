using ImageStorage.BLL.Models.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUserWithGoogleAuthAsync(CreateUserByGoogleAccountModel source);
        // Create GoogleAuthService with GoogleAuthModel
    }
}
