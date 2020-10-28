using InterfacesChallenge.Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InterfacesChallenge.DataLayer.Interfaces {
    public static class ServiceInjector {
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<IAuthorRepository, AuthorRepositoryFake>();
            
            return services;
        }
    }
}