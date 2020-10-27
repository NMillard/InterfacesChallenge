using System.Collections.Generic;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Domain;
using InterfacesChallenge.WebClient.Authors.RequestInputs;
using Microsoft.AspNetCore.Mvc;

namespace InterfacesChallenge.WebClient.Authors {
    public class GetAuthorsController : AuthorControllerBase<IEnumerable<Author>> {
        private readonly IGetAuthors getAuthors;

        public GetAuthorsController(IGetAuthors getAuthors) {
            this.getAuthors = getAuthors;
        }
        
        [HttpGet("")]
        public override async Task<ActionResult<IEnumerable<Author>>> ExecuteAsync() => Ok(await getAuthors.ExecuteAsync());
    }

    public class GetAuthorController : AuthorControllerBase<IAuthor?, string> {
        private readonly IGetAuthor getAuthor;

        public GetAuthorController(IGetAuthor getAuthor) {
            this.getAuthor = getAuthor;
        }

        [HttpGet("{penName}")]
        public override async Task<ActionResult<IAuthor?>> ExecuteAsync(string penName) {
            IAuthor? author  = await getAuthor.ExecuteAsync(penName);
            
            return author is {} ? (ActionResult) Ok(author) : NotFound();
        }
    }

    public class CreateAuthorController : AuthorControllerBase<IAuthor?, string> {
        private readonly ICreateAuthor createAuthor;

        public CreateAuthorController(ICreateAuthor createAuthor) {
            this.createAuthor = createAuthor;
        }
        
        [HttpPost("")]
        public override async Task<ActionResult<IAuthor?>> ExecuteAsync(string penName) {
            IAuthor? author = await createAuthor.ExecuteAsync(penName);
            if (author is null) return BadRequest();

            return Ok(author);
        }
    }
    
    public class BeginArticleController : AuthorControllerBase<IArticle?, BeginArticleInput> {
        private readonly IBeginArticle beginArticle;

        public BeginArticleController(IBeginArticle beginArticle) {
            this.beginArticle = beginArticle;
        }
        
        [HttpPost("article")]
        public override async Task<ActionResult<IArticle?>> ExecuteAsync(BeginArticleInput input) {
            IArticle? article = await beginArticle.ExecuteAsync(input.PenName, input.ArticleTitle);
            if (article is null) return BadRequest();
            
            return Ok(article);
        }
    }
}