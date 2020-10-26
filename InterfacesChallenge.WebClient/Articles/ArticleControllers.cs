using System.Collections.Generic;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Domain;
using Microsoft.AspNetCore.Mvc;

namespace InterfacesChallenge.WebClient.Articles {
    
    public class GetArticlesController : ArticleControllerBase<IEnumerable<Article>> {
        private readonly IGetArticles getArticles;

        public GetArticlesController(IGetArticles getArticles) {
            this.getArticles = getArticles;
        }
        
        [HttpGet("")]
        public override async Task<ActionResult<IEnumerable<Article>>> ExecuteAsync() => Ok(await getArticles.ExecuteAsync());
    }
}