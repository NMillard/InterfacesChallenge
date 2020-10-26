using InterfacesChallenge.WebClient.Generics;
using Microsoft.AspNetCore.Components;

namespace InterfacesChallenge.WebClient.Articles {
    [Route("api/articles")]
    public abstract class ArticleControllerBase<TReturn> : SingleActionBase<TReturn> { }
    
    [Route("api/articles")]
    public abstract class ArticleControllerBase<TReturn, TInput> : SingleActionBase<TReturn, TInput> { }
}