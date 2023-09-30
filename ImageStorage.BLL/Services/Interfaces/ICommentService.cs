using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Interfaces
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CreateCommentModel source, JwtUserModel jwtUser);
        Task DeleteCommentAsync(Guid id);
    }
}
