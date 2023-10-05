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
    public interface IPublicationService
    {
        Task<List<PreviewModel>> GetPublicationsPreviews(int take, int skip);
        Task CreatePublicationAsync(CreatePublicationModel source, JwtUserModel jwtUser);
        Task UpdatePublicationAsync(UpdatePublicationModel source);
        Task DeletePublicationAsync(Guid id);
    }
}
