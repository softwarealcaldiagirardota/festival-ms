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
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICompanySaleRepository, CompanySaleRepository>();
            services.AddTransient<ICompanyBusyRepository, CompanyBusyRepository>();
            services.AddTransient<IJuryRepository, JuryRepository>();
            return services;
        }
    }
}

