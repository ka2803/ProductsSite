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
    public class EnvironmentsQueryHandler : DatabaseQueryHandlerBase<EnvironmentsQuery, EnvironmentsResponse>
    {
        private readonly IMapper _mapper;

        public EnvironmentsQueryHandler(IProductPriceContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public override async Task<EnvironmentsResponse> Execute(EnvironmentsQuery query)
        {
            var envs = await DbContext.Environments.ToListAsync();

            return new EnvironmentsResponse
            {
                Environments = envs.Select(environment => _mapper.Map<Environment>(environment)).ToList()
            };
        }
    }
}