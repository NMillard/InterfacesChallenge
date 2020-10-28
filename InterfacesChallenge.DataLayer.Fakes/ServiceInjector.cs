using InterfacesChallenge.Application.Fakes.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InterfacesChallenge.DataLayer.Interfaces {
    public static class ServiceInjector {
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<IAuthorFakeRepository, AuthorRepositoryFake>();
            
            return services;
        }
    }
}