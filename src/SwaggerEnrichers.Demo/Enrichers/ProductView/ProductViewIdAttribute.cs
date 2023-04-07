using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.Demo.Enrichers;

public class ProductViewIdAttribute : Attribute, ISchemaEnricher, IParameterEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Title = "Product Id";
        schema.Description = "Product identifier";
        schema.Example = new OpenApiInteger(3);
    }

    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Product Id";
        parameter.Description = "Product identifier";
        parameter.Schema.Example = null;
    }
}