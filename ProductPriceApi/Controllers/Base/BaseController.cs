using System.Web.Http;
using ProductPrice.Abstractions.CQRS.Buses;

namespace ProductPriceApi.Controllers.Base
{
    public abstract class BaseController : ApiController
    {
        protected  IQueryBus QueryBus { get; }
        protected ICommandBus CommandBus { get; }

        protected BaseController(IQueryBus queryBus, ICommandBus commandBus)
        {
            QueryBus = queryBus;
            CommandBus = commandBus;
        }
       
    }
}