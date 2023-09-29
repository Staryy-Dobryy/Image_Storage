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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ImageSrorageDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<User>()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetByEmailWithDetailsAsync(string email)
        {
            return await _dbContext.Set<User>()
                .Include(x => x.Account)
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
