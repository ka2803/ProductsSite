using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Query
{
    public class GetAllPriceQueryHandler : DatabaseQueryHandlerBase<GetAllPricesQuery, AllPricesResponse>
    {
        private readonly IMapper _mapper;

        public GetAllPriceQueryHandler(IProductPriceContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public override async Task<AllPricesResponse> Execute(GetAllPricesQuery query)
        {
            var prices = await DbContext.ProductPrices
                .Include(product => product.Environment)
                .Include(product => product.Shipping)
                .Include(product => product.Boxing)
                .Include(product => product.Taxes)
                .ToListAsync();

            if (prices == null)
            {
                throw new InvalidOperationException();
            }

            return new AllPricesResponse
            {
                Prices = prices.Select(price =>
                    _mapper.Map<Abstractions.Contracts.Queries.SubResponses.ProductPrice>(price)).ToList()
            };
        }
    }
}