using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.Demo.Enrichers;

public class ProductViewNameAttribute : Attribute, ISchemaEnricher, IParameterEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Title = "Product Name";
        schema.Description = "Name of product";
        schema.Example = new OpenApiString("Apple Watch");
    }

    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Product Name";
        parameter.Description = "Name of product";
        parameter.Schema.Example = null;
    }
}