using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Fakes.Interfaces;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    internal class CreateAuthorFake : ICreateAuthor {
        private readonly IAuthorFakeRepository fakeRepository;

        public CreateAuthorFake(IAuthorFakeRepository fakeRepository) {
            this.fakeRepository = fakeRepository;
        }
        
        public async Task<IAuthor?> ExecuteAsync(string penName) {
            var author = new Author(penName);

            if (fakeRepository.Authors.SingleOrDefault(a => a.PenName.Equals(penName)) is {}) return null;
            bool result = fakeRepository.AddAuthor(author);

            return result ? (AuthorDto?) author : null;
        }
    }
    
    internal class BeginArticleFake : IBeginArticle {
        private readonly IAuthorFakeRepository fakeRepository;

        public BeginArticleFake(IAuthorFakeRepository fakeRepository) {
            this.fakeRepository = fakeRepository;
        }
        
        public async Task<IArticle?> ExecuteAsync(string penName, string articleTitle) {
            Author? author = fakeRepository.Authors.SingleOrDefault(a => a.PenName.Equals(penName));
            Article? article =  author?.BeginArticle(articleTitle);

            return (ArticleDto?) article;
        }
    }
}