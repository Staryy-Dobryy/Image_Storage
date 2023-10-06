using ImageStorage.BLL.Mapping;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.BLL.Services.Realization;
using ImageStorage.BLL.Tools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.Extentions
{
    public static class ServicesExtention
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            services.AddScoped<IJwtAuthService, JwtAuthService>();
            services.AddScoped<IPublicationService, PublicationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IViewService, ViewService>();
            services.AddSingleton<HashTool>();
            services.AddSingleton<SaveImageTool>();
        }
    }
}
