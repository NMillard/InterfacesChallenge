using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Application.Interfaces.Repositories;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    internal class GetAuthors : IGetAuthors {
        private readonly IAuthorRepository repository;

        public GetAuthors(IAuthorRepository repository) {
            this.repository = repository;
        }

        public async Task<IEnumerable<IAuthor>> ExecuteAsync() => repository
            .Authors
            .Select(author => new AuthorDto(
                author.PenName,
                author.Articles.Select(article => new ArticleDto(article.Title, article.CreatedTime, article.PublishedTime)))
            );
    }
    
    internal class GetAuthor : IGetAuthor {
        private readonly IAuthorRepository repository;

        public GetAuthor(IAuthorRepository repository) {
            this.repository = repository;
        }

        public async Task<IAuthor?> ExecuteAsync(string penName) {
            Author? author = repository
                .Authors
                .SingleOrDefault(a => a.PenName.Equals(penName));

            IEnumerable<IArticle> articles = author.Articles.Select(article =>
                new ArticleDto(article.Title, article.CreatedTime, article.PublishedTime));
            
            return new AuthorDto(author.PenName, articles);
        }
    }
}