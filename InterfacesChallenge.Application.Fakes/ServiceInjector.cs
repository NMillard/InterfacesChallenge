using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Fakes.Authors;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using Microsoft.Extensions.DependencyInjection;

namespace InterfacesChallenge.Application.Fakes {
    public static class ServiceInjector {
        public static IServiceCollection AddQueries(this IServiceCollection services) {
            services.AddScoped<IGetAuthors, GetAuthors>()
                .AddScoped<IGetAuthor, GetAuthor>()
                .AddScoped<IGetArticles, GetArticlesFake>();
            
            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services) {
            services.AddScoped<ICreateAuthor, CreateAuthorFake>()
                .AddScoped<IBeginArticle, BeginArticleFake>();
            
            return services;
        }
    }
}