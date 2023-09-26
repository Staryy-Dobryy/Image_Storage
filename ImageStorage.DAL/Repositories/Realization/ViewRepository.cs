using ImageStorage.DAL.Context;
using ImageStorage.DAL.Entities;
using ImageStorage.DAL.Repositories.Interfaces;
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

        protected ViewRepository(ImageSrorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddViewedPublicationByUserIdAsync(View viewObject)
        {
            await _dbContext.Set<View>().AddAsync(viewObject);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> PublicationViewedByUserIdAsync(Guid publicationId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
