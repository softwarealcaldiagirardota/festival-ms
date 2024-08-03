using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Serialization;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Festival.Ms.CrossCutting.Register
{
    public static class RegisterHandlers
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            // Add services Auth0

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
            services.AddAuthorizationDependencies(configuration);
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

