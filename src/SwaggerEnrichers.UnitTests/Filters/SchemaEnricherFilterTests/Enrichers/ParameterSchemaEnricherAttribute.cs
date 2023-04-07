using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.UnitTests.Filters.SchemaEnricherFilterTests.Enrichers;

public class ParameterSchemaEnricherAttribute : Attribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Title = "Parameter";
    }
}