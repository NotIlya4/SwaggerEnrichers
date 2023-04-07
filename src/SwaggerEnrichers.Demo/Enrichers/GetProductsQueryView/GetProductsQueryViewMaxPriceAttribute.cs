using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.Demo.Enrichers;

public class GetProductsQueryViewMaxPriceAttribute : Attribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Max Price";
        parameter.Description = "Maximum price of return products";
    }
}