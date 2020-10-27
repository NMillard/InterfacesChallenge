using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    internal class GetAuthors : IGetAuthors {
        private readonly AuthorRepositoryFake repositoryFake;

        public GetAuthors(AuthorRepositoryFake repositoryFake) {
            this.repositoryFake = repositoryFake;
        }

        public async Task<IEnumerable<IAuthor>> ExecuteAsync() => repositoryFake
            .Authors
            .Select(author => new AuthorDto(
                author.PenName,
                author.Articles.Select(article => new ArticleDto(article.Title, article.CreatedTime, article.PublishedTime)))
            );
    }
    
    internal class GetAuthor : IGetAuthor {
        private readonly AuthorRepositoryFake repositoryFake;

        public GetAuthor(AuthorRepositoryFake repositoryFake) {
            this.repositoryFake = repositoryFake;
        }

        public async Task<IAuthor?> ExecuteAsync(string penName) {
            Author? author = repositoryFake
                .Authors
                .SingleOrDefault(a => a.PenName.Equals(penName));

            IEnumerable<IArticle> articles = author.Articles.Select(article =>
                new ArticleDto(article.Title, article.CreatedTime, article.PublishedTime));
            
            return new AuthorDto(author.PenName, articles);
        }
    }
}