using ImageStorage.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.Extensions
{
    public static class DatabaseExtention
    {
        public static void InjectDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ImageSrorageDbContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
        }
    }
}
