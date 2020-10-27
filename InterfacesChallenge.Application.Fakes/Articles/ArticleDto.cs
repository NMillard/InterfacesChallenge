using System;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Articles {
    public class ArticleDto : IArticle {
        public ArticleDto(string title, DateTimeOffset createdTime, DateTimeOffset? publishedTime) {
            Title = title;
            CreatedTime = createdTime;
            PublishedTime = publishedTime;
        }

        public string Title { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset? PublishedTime { get; set; }
        
        public static explicit operator ArticleDto?(Article? article) => article is null
            ? null
            : new ArticleDto(article.Title, article.CreatedTime, article.PublishedTime);
    }
}