using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.Demo.Enrichers;

public class ProductViewPriceAttribute : Attribute, ISchemaEnricher, IParameterEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Title = "Product Price";
        schema.Description = "Dollar price of product";
        schema.Example = new OpenApiFloat(749.99f);
    }

    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Product Price";
        parameter.Description = "Dollar price of product";
        parameter.Schema.Example = null;
    }
}