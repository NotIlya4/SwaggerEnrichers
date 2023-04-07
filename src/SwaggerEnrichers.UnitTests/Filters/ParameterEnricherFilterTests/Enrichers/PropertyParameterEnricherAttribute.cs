using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.UnitTests.Filters.ParameterEnricherFilterTests.Enrichers;

public class PropertyParameterEnricherAttribute : Attribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Property";
    }
}