using InterfacesChallenge.WebClient.Generics;
using Microsoft.AspNetCore.Mvc;

namespace InterfacesChallenge.WebClient.Articles {
    /// <inheritdoc />
    [Route("api/articles")]
    public abstract class ArticleControllerBase<TReturn> : SingleActionBase<TReturn> { }
    
    /// <inheritdoc />
    [Route("api/articles")]
    public abstract class ArticleControllerBase<TReturn, TInput> : SingleActionBase<TReturn, TInput> { }
}