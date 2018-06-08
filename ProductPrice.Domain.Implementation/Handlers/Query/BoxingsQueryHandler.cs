using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Abstractions.Contracts.Queries.SubResponses;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Query
{
    public class BoxingsQueryHandler : DatabaseQueryHandlerBase<BoxingsQuery, BoxingsResponse>
    {
        private readonly IMapper _mapper;

        public BoxingsQueryHandler(IProductPriceContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public override async Task<BoxingsResponse> Execute(BoxingsQuery query)
        {
            var boxings = await DbContext.Boxes.ToListAsync();

            return new BoxingsResponse
            {
                Boxings = boxings.Select(box => _mapper.Map<Boxing>(box)).ToList()
            };
        }
    }
}