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
    public class TaxesQueryHandler : DatabaseQueryHandlerBase<TaxesQuery, TaxesResponse>
    {
        private readonly IMapper _mapper;

        public TaxesQueryHandler(IProductPriceContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public override async Task<TaxesResponse> Execute(TaxesQuery query)
        {
            var taxes = await DbContext.Taxes.Select(tax => new
            {
                tax.Id,
                tax.Value,
                tax.Title
            }).ToListAsync();

            return new TaxesResponse
            {
                Taxes = taxes.Select(arg => _mapper.Map<Tax>(arg)).ToList()
            };
        }
    }
}