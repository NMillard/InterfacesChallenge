using System.Collections.Generic;
using System.Threading.Tasks;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Interfaces.Authors {
    public interface IGetAuthors {
        Task<IEnumerable<IAuthor>> ExecuteAsync();
    }

    public interface IGetAuthor {
        Task<IAuthor?> ExecuteAsync(string penName);
    }
}