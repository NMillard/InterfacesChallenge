using System.Collections.Generic;
using System.Threading.Tasks;
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

    public class GetAuthorController : AuthorControllerBase<Author?, string> {
        private readonly IGetAuthor getAuthor;

        public GetAuthorController(IGetAuthor getAuthor) {
            this.getAuthor = getAuthor;
        }

        [HttpGet("{penName}")]
        public override async Task<ActionResult<Author?>> ExecuteAsync(string penName) {
            Author? author  = await getAuthor.ExecuteAsync(penName);
            
            return author is {} ? (ActionResult) Ok(author) : NotFound();
        }
    }

    public class CreateAuthorController : AuthorControllerBase<Author?, string> {
        private readonly ICreateAuthor createAuthor;

        public CreateAuthorController(ICreateAuthor createAuthor) {
            this.createAuthor = createAuthor;
        }
        
        [HttpPost("")]
        public override async Task<ActionResult<Author?>> ExecuteAsync(string penName) {
            Author? author = await createAuthor.ExecuteAsync(penName);
            if (author is null) return BadRequest();

            return Ok(author);
        }
    }
    
    public class BeginArticleController : AuthorControllerBase<Article?, BeginArticleInput> {
        private readonly IBeginArticle beginArticle;

        public BeginArticleController(IBeginArticle beginArticle) {
            this.beginArticle = beginArticle;
        }
        
        [HttpPost("article")]
        public override async Task<ActionResult<Article?>> ExecuteAsync(BeginArticleInput input) {
            Article? article = await beginArticle.ExecuteAsync(input.PenName, input.ArticleTitle);
            if (article is null) return BadRequest();
            
            return Ok(article);
        }
    }
}