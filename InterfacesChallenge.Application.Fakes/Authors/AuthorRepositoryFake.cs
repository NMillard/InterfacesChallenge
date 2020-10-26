using System.Collections.Generic;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    public class AuthorRepositoryFake {
        public AuthorRepositoryFake() {
            var nicm = new Author("nicm");
            nicm.BeginArticle("My article");
            var ems = new Author("ems");
            
            Authors = new List<Author> {
                nicm,
                ems,
            };
        }
        
        public List<Author> Authors { get; }
    }
}