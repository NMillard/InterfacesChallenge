using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Repositories;

namespace InterfacesChallenge.Application.Fakes.Articles {
    public class GetArticlesFake : IGetArticles {
        private readonly IAuthorRepository repository;

        public GetArticlesFake(IAuthorRepository repository) {
            this.repository = repository;
        }
        
        public async Task<IEnumerable<IArticle>> ExecuteAsync() => repository.Authors.SelectMany(a => a.Articles)
            .Select(article => (ArticleDto) article);
    }
}