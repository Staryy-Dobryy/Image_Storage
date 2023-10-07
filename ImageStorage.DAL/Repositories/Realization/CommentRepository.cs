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
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ImageSrorageDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Comment> AddAndReturnWithDetailsAsync(Comment comment)
        {
            var createdEntity = await _dbContext.Set<Comment>().AddAsync(comment);

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Set<Comment>()
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == createdEntity.Entity.Id);
        }
    }
}
