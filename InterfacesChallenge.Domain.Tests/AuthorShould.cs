using Xunit;

namespace InterfacesChallenge.Domain.Tests {
    public class AuthorShould {
        [Fact]
        public void UpdateAuthorsPenName() {
            string newPenName = "ems";
            
            var sut = new Author("nicm");
            
            // Act
            sut.UpdatePenName(newPenName);
            
            Assert.Equal(newPenName, sut.PenName);
        }
        
        [Fact]
        public void BeginNewArticle() {
            var sut = new Author("nicm");

            // Act
            sut.BeginArticle("New article");

            Assert.Single(sut.Articles);
        }
        
        [Fact]
        public void NotHaveArticlesWithSameTitle() {
            var sut = new Author("nicm");

            // Act
            Article article1 =  sut.BeginArticle("Article1");
            Article article2 = sut.BeginArticle("Article1");
            
            Assert.NotNull(article1);
            Assert.Null(article2);
        }

        [Fact]
        public void DeleteArticleByTitle() {
            var sut = new Author("nicm");
            sut.BeginArticle("new article");
            
            // Act
            sut.DeleteArticle("new article");
            
            Assert.Empty(sut.Articles);
        }
    }
}