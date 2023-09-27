using ImageStorage.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.Repositories.Interfaces
{
    public interface IPublicationRepository : IBaseRepository<Publication>
    {
        Task<Publication?> GetWithDetailsByIdAsync(Guid publicationId);
        Task<IEnumerable<Comment>?> GetCommentsByPublicationIdAsync(Guid publicationId);
        Task<IEnumerable<Publication>> GetPopularPublicationsAsync(int take, int skip);
    }
}
