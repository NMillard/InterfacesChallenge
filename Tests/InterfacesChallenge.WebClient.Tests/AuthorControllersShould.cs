using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Fakes.Authors;
using InterfacesChallenge.Application.Interfaces.Articles;
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
            var authorsFromRepository = new List<IAuthor> {
                new AuthorDto("nicm", new List<IArticle>()),
                new AuthorDto("ems", new List<IArticle>())
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
            var collection = Assert.IsAssignableFrom<IEnumerable<IAuthor>>(returnResult.Value);
            Assert.True(collection.Count() == 2);
        }
        
        [Fact]
        public async Task GetSingleAuthor() {
            string penName = "nicm";
            
            var getAuthors = new Mock<IGetAuthor>();
            getAuthors.Setup(x => x.ExecuteAsync(penName))
                .ReturnsAsync(new AuthorDto(penName, new List<IArticle>()))
                .Verifiable();
            
            var sut = new GetAuthorController(getAuthors.Object);

            // Act
            ActionResult<IAuthor?> response = await sut.ExecuteAsync(penName);
            
            // Asserts
            var returnResult = Assert.IsType<OkObjectResult>(response.Result);
            Assert.IsAssignableFrom<IAuthor>(returnResult.Value);
        }
        
        [Fact]
        public async Task NotFindAuthor() {
            string penName = "nicm";
            
            var getAuthors = new Mock<IGetAuthor>();
            getAuthors.Setup(x => x.ExecuteAsync(penName))
                .ReturnsAsync((IAuthor) null!)
                .Verifiable();
            
            var sut = new GetAuthorController(getAuthors.Object);

            // Act
            ActionResult<IAuthor?> response = await sut.ExecuteAsync(penName);
            
            // Asserts
            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task CreateAnAuthor() {
            string penName = "nicm";

            var author = new AuthorDto(penName, new List<IArticle>());
            
            var beginArticle = new Mock<ICreateAuthor>();
            beginArticle.Setup(x => x.ExecuteAsync(penName))
                .ReturnsAsync(author)
                .Verifiable();
            
            var sut = new CreateAuthorController(beginArticle.Object);

            // Act
            ActionResult<IAuthor?> response = await sut.ExecuteAsync(penName);

            // Assert
            var returnResult =  Assert.IsType<OkObjectResult>(response.Result);
            Assert.IsAssignableFrom<IAuthor>(returnResult.Value);
        }
        
        [Fact]
        public async Task BeginArticleForAuthor() {
            string penName = "nicm";
            string articleTitle = "new article";

            var beginArticle = new Mock<IBeginArticle>();
            beginArticle.Setup(x => x.ExecuteAsync(penName, articleTitle))
                .ReturnsAsync(new ArticleDto(articleTitle, DateTimeOffset.Now, null))
                .Verifiable();
            
            var sut = new BeginArticleController(beginArticle.Object);
            var input = new BeginArticleInput {
                PenName = penName,
                ArticleTitle = articleTitle
            };

            // Act
            ActionResult<IArticle?> response = await sut.ExecuteAsync(input);

            // Assert
            var model = Assert.IsType<OkObjectResult>(response.Result);
            Assert.IsAssignableFrom<IArticle>(model.Value);
        }
        
        [Fact]
        public async Task NotBeginArticleForAuthor() {
            string penName = "nicm";
            string articleTitle = "new article";
            
            var beginArticle = new Mock<IBeginArticle>();
            beginArticle.Setup(x => x.ExecuteAsync(penName, articleTitle))
                .ReturnsAsync((IArticle) null!)
                .Verifiable();
            
            var sut = new BeginArticleController(beginArticle.Object);
            var input = new BeginArticleInput {
                PenName = penName,
                ArticleTitle = articleTitle
            };

            // Act
            ActionResult<IArticle?> response = await sut.ExecuteAsync(input);
            
            Assert.IsType<BadRequestResult>(response.Result);
            Assert.Null(response.Value);
        }
    }
}