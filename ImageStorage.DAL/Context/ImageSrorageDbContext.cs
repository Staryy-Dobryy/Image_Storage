using ImageStorage.DAL.Entities;
using ImageStorage.DAL.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ImageStorage.DAL.Context
{
    public class ImageSrorageDbContext : DbContext
    {
        public ImageSrorageDbContext() { }

        public ImageSrorageDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<View> Views { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PublicationConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new ViewConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
