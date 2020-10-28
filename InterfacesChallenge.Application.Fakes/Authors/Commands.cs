using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Application.Interfaces.Repositories;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    internal class CreateAuthorFake : ICreateAuthor {
        private readonly IAuthorRepository repository;

        public CreateAuthorFake(IAuthorRepository repository) {
            this.repository = repository;
        }
        
        public async Task<IAuthor?> ExecuteAsync(string penName) {
            var author = new Author(penName);

            if (repository.Authors.SingleOrDefault(a => a.PenName.Equals(penName)) is {}) return null;
            bool result = repository.AddAuthor(author);

            return result ? (AuthorDto?) author : null;
        }
    }
    
    internal class BeginArticleFake : IBeginArticle {
        private readonly IAuthorRepository repository;

        public BeginArticleFake(IAuthorRepository repository) {
            this.repository = repository;
        }
        
        public async Task<IArticle?> ExecuteAsync(string penName, string articleTitle) {
            Author? author = repository.Authors.SingleOrDefault(a => a.PenName.Equals(penName));
            Article? article =  author?.BeginArticle(articleTitle);

            return (ArticleDto?) article;
        }
    }
}