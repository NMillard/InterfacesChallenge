using System.Collections.Generic;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Interfaces {
    public interface IAuthorFakeRepository {
        IEnumerable<Author> Authors { get; }
        bool AddAuthor(Author author);
    }
}