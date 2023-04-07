using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.Demo.Enrichers;

public class GetProductsQueryViewMinPriceAttribute : Attribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Min Price";
        parameter.Description = "Minimum price of return products";
    }
}