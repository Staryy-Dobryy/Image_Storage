using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Models.UpdateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task UpdateUserInfoAsync(UpdateUserModel source, JwtUserModel jwtUser);
    }
}
