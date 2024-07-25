using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Serialization;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL;
using Microsoft.EntityFrameworkCore;

namespace Festival.Ms.CrossCutting.Register
{
    public static class RegisterHandlers
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFestivalContext, FestivalContext>();
            services.AddDbContext<FestivalContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ApiConnection"));
            });

            services.AddServiceDependencies();
            services.AddRepositoryDependencies();
        }
    }
}

