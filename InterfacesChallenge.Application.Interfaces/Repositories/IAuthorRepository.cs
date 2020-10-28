using System.Collections.Generic;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Interfaces.Repositories {
    public interface IAuthorRepository {
        IEnumerable<Author> Authors { get; }
        bool AddAuthor(Author author);
    }
}