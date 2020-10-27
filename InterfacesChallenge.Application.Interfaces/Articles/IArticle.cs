using System;

namespace InterfacesChallenge.Application.Interfaces.Articles {
    public interface IArticle {
        string Title { get; }
        DateTimeOffset CreatedTime { get; }
        DateTimeOffset? PublishedTime { get; }
    }
}