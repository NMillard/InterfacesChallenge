using System.Collections.Generic;
using System.Threading.Tasks;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Interfaces.Authors {
    public interface IGetAuthors {
        Task<IEnumerable<Author>> ExecuteAsync();
    }

    public interface IGetAuthor {
        Task<Author?> ExecuteAsync(string penName);
    }
}