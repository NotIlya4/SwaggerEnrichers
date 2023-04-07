using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.UnitTests.Filters.SchemaEnricherFilterTests.Enrichers;

public class PropertySchemaEnricherAttribute : Attribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Title = "Property";
    }
}