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
    public class ShippingsQueryHandler : DatabaseQueryHandlerBase<ShippingsQuery, ShippingsResponse>
    {
        private readonly IMapper _mapper;

        public ShippingsQueryHandler(IProductPriceContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public override async Task<ShippingsResponse> Execute(ShippingsQuery query)
        {
            var ships = await DbContext.Shippings.ToListAsync();

            return new ShippingsResponse
            {
                Shippings = ships.Select(shipping => _mapper.Map<Shipping>(shipping)).ToList()
            };
        }
    }
}