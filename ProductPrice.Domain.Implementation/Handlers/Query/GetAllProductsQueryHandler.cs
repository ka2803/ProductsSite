using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Abstractions.Contracts.Queries.SubResponses;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;
using Product = ProductPrice.Domain.Database.Entities.Product;

namespace ProductPrice.Domain.Implementation.Handlers.Query
{
    public class GetAllProductsQueryHandler : DatabaseQueryHandlerBase<GetAllProductsQuery, AllProductsResponse>
    {
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductPriceContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public override async Task<AllProductsResponse> Execute(GetAllProductsQuery query)
        {
            var products = await DbContext.Products
                .Include(product => product.ProductPrice)
                .Include(product => product.ProductPrice.Environment)
                .Include(product => product.ProductPrice.Shipping)
                .Include(product => product.ProductPrice.Boxing)
                .Include(product => product.ProductPrice.Taxes)
                .ToListAsync();

            if (products == null)
            {
                throw new InvalidOperationException();
            }

            return new AllProductsResponse
            {
                Products = products.Select(product =>
                    _mapper.Map<Abstractions.Contracts.Queries.SubResponses.Product>(product)).ToList()
            };
        }
    }
}