using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Repositories;
using Festival.Ms.DTO.Models;
using Microsoft.Extensions.DependencyInjection;
namespace Festival.Ms.CrossCutting.Register
{
    public static class RepositoryDependencies
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddTransient<IFestivalRepository, FestivalRepository>();
            services.AddTransient<IVoteRepository, VoteRepository>();
            services.AddTransient<IParticipationCompanyRepository, ParticipationCompanyRepository>();
            services.AddTransient<IDeviceParticipationRepository, DeviceParticipationRepository>();
            return services;
        }
    }
}

