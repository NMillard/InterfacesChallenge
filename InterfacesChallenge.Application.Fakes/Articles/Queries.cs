using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Interfaces;
using InterfacesChallenge.Application.Interfaces.Articles;

namespace InterfacesChallenge.Application.Fakes.Articles {
    public class GetArticlesFake : IGetArticles {
        private readonly IAuthorFakeRepository fakeRepository;

        public GetArticlesFake(IAuthorFakeRepository fakeRepository) {
            this.fakeRepository = fakeRepository;
        }
        
        public async Task<IEnumerable<IArticle>> ExecuteAsync() => fakeRepository.Authors.SelectMany(a => a.Articles)
            .Select(article => (ArticleDto) article);
    }
}