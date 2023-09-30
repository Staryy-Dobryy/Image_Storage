using AutoMapper;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.DAL.Entities;
using ImageStorage.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Realization
{
    public class ViewService : IViewService
    {
        private readonly IViewRepository _viewRepository;
        private readonly IPublicationRepository _publicationRepository;

        public ViewService(IViewRepository viewRepository, IPublicationRepository publicationRepository, IMapper mapper)
        {
            _viewRepository = viewRepository;
            _publicationRepository = publicationRepository;
        }

        public async Task CreateViewOnPublication(Guid publicationId, JwtUserModel jwtUser)
        {
            bool viewed = await _viewRepository.PublicationViewedByUserIdAsync(publicationId, jwtUser.Id);

            if (viewed)
            {
                return;
            }

            var publication = await _publicationRepository.GetByIdAsync(publicationId);
            publication.ViewsCount++;
            await _publicationRepository.UpdateAsync(publication);

            View view = new()
            {
                PublicationId = publicationId,
                UserId = jwtUser.Id
            };
            await _viewRepository.AddViewedPublicationByUserIdAsync(view);
        }
    }
}
