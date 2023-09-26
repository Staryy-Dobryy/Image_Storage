using ImageStorage.DAL.Context;
using ImageStorage.DAL.Repositories.Interfaces;
using ImageStorage.DAL.Repositories.Realization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.Extentions
{
    public static class DatabaseExtention
    {
        public static void InjectDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IViewRepository, ViewRepository>();
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ImageSrorageDbContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
        }
    }
}
