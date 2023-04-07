using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.UnitTests.Filters.ParameterEnricherFilterTests.Enrichers;

public class ParameterParameterEnricherAttribute : Attribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Parameter";
    }
}