using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InterfacesChallenge.WebClient.Generics {
    
    /// <summary>
    ///     Define a controller with only a single action.
    /// </summary>
    /// <typeparam name="TReturn">Type the single action should return.</typeparam>
    public abstract class SingleActionBase<TReturn> : ControllerBase {
        public abstract Task<ActionResult<TReturn>> ExecuteAsync();
    }

    /// <summary>
    ///     Define a controller with only a single action.
    /// </summary>
    /// <typeparam name="TReturn">Type the single action should return.</typeparam>
    /// <typeparam name="TInput">Type the single action takes as a parameter.</typeparam>
    public abstract class SingleActionBase<TReturn, TInput> : ControllerBase {
        public abstract Task<ActionResult<TReturn>> ExecuteAsync(TInput penName);
    }
}