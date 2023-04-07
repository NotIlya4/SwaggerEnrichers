using System.Reflection;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateOwnEnrichers;
using SwaggerEnrichers.EnricherProviders;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerEnrichers.Filters;

internal class ParameterEnricherFilter : IParameterFilter
{
    private readonly IParameterEnricherProvider _enricherProvider = new EnricherProvider();
    
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        Enrich(parameter, context.PropertyInfo);
        Enrich(parameter, context.ParameterInfo);
    }

    private void Enrich(OpenApiParameter parameter, ICustomAttributeProvider? attributeProvider)
    {
        IParameterEnricher? enricher = _enricherProvider.GetParameterEnricher(attributeProvider);

        enricher?.Enrich(parameter);
    }
}