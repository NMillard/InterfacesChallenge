using System.Threading.Tasks;
using InterfacesChallenge.Application.Interfaces.Articles;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Interfaces.Authors {
    public interface ICreateAuthor {
        Task<IAuthor?> ExecuteAsync(string penName);
    }
    
    public interface IBeginArticle {
        Task<IArticle?> ExecuteAsync(string penName, string articleTitle);
    }
}