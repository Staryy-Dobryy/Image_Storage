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
    public class ViewRepository : IViewRepository
    {
        protected ImageSrorageDbContext _dbContext;

        public ViewRepository(ImageSrorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddViewedPublicationByUserIdAsync(View viewObject)
        {
            await _dbContext.Set<View>().AddAsync(viewObject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> PublicationViewedByUserIdAsync(Guid publicationId, Guid userId)
        {
            return await _dbContext.Set<View>()
                .AnyAsync(x => x.PublicationId == publicationId && x.UserId == userId);
        }
    }
}
