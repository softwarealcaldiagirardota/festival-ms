using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Festival.Ms.CrossCutting.Register
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IFestivalService, FestivalService>();
            return services;
        }
    }
}

