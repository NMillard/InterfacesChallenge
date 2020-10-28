using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Fakes.Interfaces;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    internal class GetAuthors : IGetAuthors {
        private readonly IAuthorFakeRepository fakeRepository;

        public GetAuthors(IAuthorFakeRepository fakeRepository) {
            this.fakeRepository = fakeRepository;
        }

        public async Task<IEnumerable<IAuthor>> ExecuteAsync() => fakeRepository
            .Authors
            .Select(author => new AuthorDto(
                author.PenName,
                author.Articles.Select(article => new ArticleDto(article.Title, article.CreatedTime, article.PublishedTime)))
            );
    }
    
    internal class GetAuthor : IGetAuthor {
        private readonly IAuthorFakeRepository fakeRepository;

        public GetAuthor(IAuthorFakeRepository fakeRepository) {
            this.fakeRepository = fakeRepository;
        }

        public async Task<IAuthor?> ExecuteAsync(string penName) {
            Author? author = fakeRepository
                .Authors
                .SingleOrDefault(a => a.PenName.Equals(penName));

            IEnumerable<IArticle> articles = author.Articles.Select(article =>
                new ArticleDto(article.Title, article.CreatedTime, article.PublishedTime));
            
            return new AuthorDto(author.PenName, articles);
        }
    }
}