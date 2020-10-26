using InterfacesChallenge.WebClient.Generics;
using Microsoft.AspNetCore.Mvc;

namespace InterfacesChallenge.WebClient.Authors {
    [Route("api/authors")]
    public abstract class AuthorControllerBase<TReturn> : SingleActionBase<TReturn> { }

    [Route("api/authors")]
    public abstract class AuthorControllerBase<TReturn, TInput> : SingleActionBase<TReturn, TInput> { }
}