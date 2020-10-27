using System.Collections.Generic;
using InterfacesChallenge.Application.Interfaces.Articles;

namespace InterfacesChallenge.Application.Interfaces.Authors {
    public interface IAuthor {
        string PenName { get; }
        IEnumerable<IArticle> Articles { get; }
    }
}