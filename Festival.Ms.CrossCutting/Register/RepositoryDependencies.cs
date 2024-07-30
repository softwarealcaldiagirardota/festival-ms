using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Festival.Ms.CrossCutting.Register
{
    public static class RepositoryDependencies
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddTransient<IFestivalRepository, FestivalRepository>();
            return services;
        }
    }
}

