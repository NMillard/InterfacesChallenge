using System.Collections.Generic;
using System.Linq;
using InterfacesChallenge.Application.Fakes.Interfaces;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.DataLayer.Interfaces {
    internal class AuthorRepositoryFake : IAuthorFakeRepository {
        private readonly List<Author> authors;
        
        public AuthorRepositoryFake() {
            var nicm = new Author("nicm");
            nicm.BeginArticle("My article");
            var ems = new Author("ems");
            
            authors = new List<Author> {
                nicm,
                ems,
            };
        }

        public IEnumerable<Author> Authors => authors.AsReadOnly();
        
        public bool AddAuthor(Author author) {
            if (authors.SingleOrDefault(a => a.PenName.Equals(author.PenName)) is {}) return false;
            authors.Add(author);

            return true;
        }
    }
}