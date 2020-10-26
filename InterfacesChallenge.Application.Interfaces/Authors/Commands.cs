using System.Threading.Tasks;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Interfaces.Authors {
    public interface ICreateAuthor {
        Task<Author?> ExecuteAsync(string penName);
    }
    
    public interface IBeginArticle {
        Task<Article?> ExecuteAsync(string penName, string articleTitle);
    }
}