using System.Collections.Generic;
using System.Threading.Tasks;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Interfaces.Articles {
    public interface IGetArticles {
        Task<IEnumerable<Article>> ExecuteAsync();
    }
}