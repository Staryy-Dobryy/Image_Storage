using ImageStorage.DAL.Context;
using ImageStorage.DAL.Entities;
using ImageStorage.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.Repositories.Realization
{
    public class PublicationRepository : BaseRepository<Publication>, IPublicationRepository
    {
        public PublicationRepository(ImageSrorageDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Publication>> GetAllByUserIdAsync(Guid userId, bool onlyPublic = false)
        {
            if (onlyPublic)
            {
                return await _dbContext.Set<Publication>()
                    .Where(x => x.AuthorId == userId && x.IsPublic == true)
                    .ToListAsync();
            }

            return await _dbContext.Set<Publication>()
                .Where(x => x.AuthorId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>?> GetCommentsByPublicationIdAsync(Guid publicationId)
        {
            var publication = await _dbContext.Set<Publication>()
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == publicationId);

            if (publication is null)
            {
                return null;
            }

            return publication.Comments;
        }

        public async Task<IEnumerable<Publication>> GetPopularPublicationsAsync(int take, int skip)
        {
            var average = await _dbContext.Set<Publication>()
                .Where(x => x.IsPublic)
                .AverageAsync(x => x.ViewsCount);

            return await _dbContext.Set<Publication>()
                .Where(x => x.ViewsCount >= average && x.IsPublic)
                .OrderBy(x => x.ViewsCount)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<Publication?> GetWithDetailsByIdAsync(Guid publicationId)
        {
            return await _dbContext.Set<Publication>()
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == publicationId);
        }
    }
}
