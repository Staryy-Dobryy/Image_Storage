using AutoMapper;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Models.UpdateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.DAL.Entities;
using ImageStorage.DAL.Repositories.Interfaces;
using ImageStorage.DAL.Repositories.Realization;
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

        public PublicationService(IPublicationRepository publicationRepository, IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _mapper = mapper;
        }

        public async Task CreatePublicationAsync(CreatePublicationModel source, JwtUserModel jwtUser)
        {
            var publication = _mapper.Map<Publication>(source);
            publication.AuthorId = jwtUser.Id;

            await _publicationRepository.AddAsync(publication);
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
    }
}
