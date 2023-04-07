using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.Demo.Enrichers;

public class ProductViewTypeAttribute : Attribute, ISchemaEnricher, IParameterEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Title = "Product Type";
        schema.Description = "Type of product, such as Smartphone, Watches and etc";
        schema.Example = new OpenApiString("Watches");
    }

    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Product Type";
        parameter.Description = "Type of product, such as Smartphone, Watches and etc";
        parameter.Schema.Example = null;
    }
}