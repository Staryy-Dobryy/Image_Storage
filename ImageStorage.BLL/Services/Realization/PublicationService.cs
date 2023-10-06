using AutoMapper;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Models.UpdateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.BLL.Tools;
using ImageStorage.DAL.Entities;
using ImageStorage.DAL.Repositories.Interfaces;
using ImageStorage.DAL.Repositories.Realization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Realization
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IMapper _mapper;
        private readonly SaveImageTool _saveImageTool;

        public PublicationService(IPublicationRepository publicationRepository, IMapper mapper, SaveImageTool saveImageTool)
        {
            _publicationRepository = publicationRepository;
            _mapper = mapper;
            _saveImageTool = saveImageTool;
        }

        public async Task CreatePublicationAsync(CreatePublicationModel source, JwtUserModel jwtUser, IFormFile image, string webRootPath)
        {
            await _saveImageTool.SaveImageAsync(image, webRootPath, source.ImageUrl);

            var publication = _mapper.Map<Publication>(source);
            publication.AuthorId = jwtUser.Id;

            await _publicationRepository.AddAndReturnAsync(publication);
        }

        public async Task<PreviewModel> CreateAndReturnPublicationAsync(CreatePublicationModel source, JwtUserModel jwtUser, IFormFile image, string webRootPath)
        {
            await _saveImageTool.SaveImageAsync(image, webRootPath, source.ImageUrl);

            var publication = _mapper.Map<Publication>(source);
            publication.AuthorId = jwtUser.Id;

            var result = await _publicationRepository.AddAndReturnAsync(publication);

            return _mapper.Map<PreviewModel>(result);
        }

        public async Task UpdatePublicationAsync(UpdatePublicationModel source)
        {
            var oldPublication = await _publicationRepository.GetByIdAsync(Guid.Parse(source.Id));
            var newPublication = _mapper.Map(source, oldPublication);

            await _publicationRepository.UpdateAsync(newPublication);
        }

        public async Task DeletePublicationAsync(Guid id)
        {
            await _publicationRepository.DeleteAsync(id);
        }

        public async Task<List<PreviewModel>> GetPublicationsPreviews(int take, int skip)
        {
            var publicationsList = await _publicationRepository.GetPopularPublicationsAsync(take, skip);

            return _mapper.Map<List<PreviewModel>>(publicationsList);
        }

        public async Task<List<PreviewModel>> GetUserGalleryAsync(JwtUserModel jwtUser)
        {
            var publicationsList = await _publicationRepository.GetAllBuUserIdAsync(jwtUser.Id);

            return _mapper.Map<List<PreviewModel>>(publicationsList);
        }

        public async Task<PublicationModel> GetPublicationById(Guid publicationId)
        {
            var publication = await _publicationRepository.GetWithDetailsByIdAsync(publicationId);

            return _mapper.Map<PublicationModel>(publication);
        }
    }
}
