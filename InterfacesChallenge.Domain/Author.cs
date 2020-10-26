using System;
using System.Collections.Generic;
using System.Linq;

namespace InterfacesChallenge.Domain {
    public class Author {
        private Guid id;
        private readonly List<Article> articles;

        public Author(string penName) {
            this.id = Guid.NewGuid();
            articles = new List<Article>();
            PenName = penName;
        }

        public string PenName { get; private set; }
        public IReadOnlyList<Article> Articles => articles.AsReadOnly();

        public void UpdatePenName(string penName) {
            if (string.IsNullOrEmpty(penName)) return;
            PenName = penName;
        }
        
        public Article? BeginArticle(string articleTitle) {
            if (articles.Any(a => a.Title.Equals(articleTitle))) return null;
            
            var article = new Article(articleTitle);
            articles.Add(article);

            return article;
        }

        public void DeleteArticle(string articleTitle) {
            Article? toDelete = articles.SingleOrDefault(a => a.Title.Equals(articleTitle));
            if (toDelete is {}) articles.Remove(toDelete);
        }
    }
}