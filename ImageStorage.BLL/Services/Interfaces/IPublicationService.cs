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
    public interface IPublicationService
    {
        Task<List<PreviewModel>> GetUserGalleryAsync(JwtUserModel jwtUser);
        Task<List<PreviewModel>> GetPublicationsPreviews(int take, int skip);
        Task<PublicationModel> GetPublicationById(Guid publicationId);
        Task<PreviewModel> CreateAndReturnPublicationAsync(CreatePublicationModel source, JwtUserModel jwtUser, IFormFile image, string webRootPath);
        Task CreatePublicationAsync(CreatePublicationModel source, JwtUserModel jwtUser, IFormFile image, string webRootPath);
        Task UpdatePublicationAsync(UpdatePublicationModel source);
        Task DeletePublicationAsync(Guid id);
    }
}
