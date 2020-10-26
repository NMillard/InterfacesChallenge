using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Domain;
using InterfacesChallenge.WebClient.Authors;
using InterfacesChallenge.WebClient.Authors.RequestInputs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InterfacesChallenge.WebClient.Tests {
    public class AuthorControllersShould {
        [Fact]
        public async Task GetAllAuthors() {
            var authorsFromRepository = new List<Author> {
                new Author("nicm"),
                new Author("ems")
            };
            
            var getAuthors = new Mock<IGetAuthors>();
            getAuthors.Setup(x => x.ExecuteAsync())
                .ReturnsAsync(authorsFromRepository)
                .Verifiable();
            
            var sut = new GetAuthorsController(getAuthors.Object);

            // Act
            ActionResult<IEnumerable<Author>> response = await sut.ExecuteAsync();
            
            // Asserts
            var returnResult = Assert.IsType<OkObjectResult>(response.Result);
            var collection = Assert.IsAssignableFrom<IEnumerable<Author>>(returnResult.Value);
            Assert.True(collection.Count() == 2);
        }
        
        [Fact]
        public async Task GetSingleAuthor() {
            string penName = "nicm";
            
            var getAuthors = new Mock<IGetAuthor>();
            getAuthors.Setup(x => x.ExecuteAsync(penName))
                .ReturnsAsync(new Author(penName))
                .Verifiable();
            
            var sut = new GetAuthorController(getAuthors.Object);

            // Act
            ActionResult<Author?> response = await sut.ExecuteAsync(penName);
            
            // Asserts
            var returnResult = Assert.IsType<OkObjectResult>(response.Result);
            Assert.IsAssignableFrom<Author>(returnResult.Value);
        }
        
        [Fact]
        public async Task NotFindAuthor() {
            string penName = "nicm";
            
            var getAuthors = new Mock<IGetAuthor>();
            getAuthors.Setup(x => x.ExecuteAsync(penName))
                .ReturnsAsync((Author) null!)
                .Verifiable();
            
            var sut = new GetAuthorController(getAuthors.Object);

            // Act
            ActionResult<Author?> response = await sut.ExecuteAsync(penName);
            
            // Asserts
            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task CreateAnAuthor() {
            string penName = "nicm";

            var author = new Author(penName);
            
            var beginArticle = new Mock<ICreateAuthor>();
            beginArticle.Setup(x => x.ExecuteAsync(penName))
                .ReturnsAsync(author)
                .Verifiable();
            
            var sut = new CreateAuthorController(beginArticle.Object);

            // Act
            ActionResult<Author?> response = await sut.ExecuteAsync(penName);

            // Assert
            var returnResult =  Assert.IsType<OkObjectResult>(response.Result);
            Assert.IsAssignableFrom<Author>(returnResult.Value);
        }
        
        [Fact]
        public async Task BeginArticleForAuthor() {
            string penName = "nicm";
            string articleTitle = "new article";

            var author = new Author(penName);
            var article = author.BeginArticle(articleTitle);
            
            var beginArticle = new Mock<IBeginArticle>();
            beginArticle.Setup(x => x.ExecuteAsync(penName, articleTitle))
                .ReturnsAsync(article)
                .Verifiable();
            
            var sut = new BeginArticleController(beginArticle.Object);
            var input = new BeginArticleInput {
                PenName = penName,
                ArticleTitle = articleTitle
            };

            // Act
            ActionResult<Article?> response = await sut.ExecuteAsync(input);

            // Assert
            var model = Assert.IsType<OkObjectResult>(response.Result);
            Assert.IsAssignableFrom<Article>(model.Value);
        }
        
        [Fact]
        public async Task NotBeginArticleForAuthor() {
            string penName = "nicm";
            string articleTitle = "new article";
            
            var author = new Author(penName);
            author.BeginArticle(articleTitle);
            Article? nullArticle = author.BeginArticle(articleTitle);
            
            var beginArticle = new Mock<IBeginArticle>();
            beginArticle.Setup(x => x.ExecuteAsync(penName, articleTitle))
                .ReturnsAsync(nullArticle)
                .Verifiable();
            
            var sut = new BeginArticleController(beginArticle.Object);
            var input = new BeginArticleInput {
                PenName = penName,
                ArticleTitle = articleTitle
            };

            // Act
            ActionResult<Article?> response = await sut.ExecuteAsync(input);
            
            Assert.IsType<BadRequestResult>(response.Result);
            Assert.Null(response.Value);
        }
    }
}