using System.Data.Entity;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Query
{
    public class CustomPropertiesQueryHandler : DatabaseQueryHandlerBase<CustomPropertiesQuery, CustomPropertiesResponse>
    {
        public CustomPropertiesQueryHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task<CustomPropertiesResponse> Execute(CustomPropertiesQuery query)
        {
            var customProperties = await DbContext.CustomProperties.ToListAsync();

            return new CustomPropertiesResponse
            {
                CustomProperties = JToken.FromObject(customProperties, JsonSerializer.CreateDefault(new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    //PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }))
            };
        }
    }
}