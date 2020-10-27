using System.Collections.Generic;
using System.Linq;
using InterfacesChallenge.Application.Fakes.Articles;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    public class AuthorDto : IAuthor {
        public AuthorDto(string penName, IEnumerable<IArticle> articles) {
            PenName = penName;
            Articles = articles;
        }

        public string PenName { get; }
        public IEnumerable<IArticle> Articles { get; }

        public static explicit operator AuthorDto?(Author? author) => author is null
            ? null
            : new AuthorDto(author.PenName, author.Articles.Select(article => (ArticleDto) article));
    }
}