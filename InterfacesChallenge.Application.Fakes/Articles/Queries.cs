using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Authors;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Articles {
    public class GetArticlesFake : IGetArticles {
        private readonly AuthorRepositoryFake repository;

        public GetArticlesFake(AuthorRepositoryFake repository) {
            this.repository = repository;
        }
        
        public async Task<IEnumerable<IArticle>> ExecuteAsync() => repository.Authors.SelectMany(a => a.Articles)
            .Select(article => (ArticleDto) article);
    }
}