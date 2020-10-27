using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    internal class CreateAuthorFake : ICreateAuthor {
        private readonly AuthorRepositoryFake repositoryFake;

        public CreateAuthorFake(AuthorRepositoryFake repositoryFake) {
            this.repositoryFake = repositoryFake;
        }
        
        public async Task<IAuthor?> ExecuteAsync(string penName) {
            var author = new Author(penName);

            if (repositoryFake.Authors.SingleOrDefault(a => a.PenName.Equals(penName)) is {}) return null;
            repositoryFake.Authors.Add(author);

            return (AuthorDto?) author;
        }
    }
    
    internal class BeginArticleFake : IBeginArticle {
        private readonly AuthorRepositoryFake repositoryFake;

        public BeginArticleFake(AuthorRepositoryFake repositoryFake) {
            this.repositoryFake = repositoryFake;
        }
        
        public async Task<IArticle?> ExecuteAsync(string penName, string articleTitle) {
            Author? author = repositoryFake.Authors.SingleOrDefault(a => a.PenName.Equals(penName));
            Article? article =  author?.BeginArticle(articleTitle);

            return (ArticleDto?) article;
        }
    }
}