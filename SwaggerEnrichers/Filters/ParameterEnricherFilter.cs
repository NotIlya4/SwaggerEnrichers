using System.Reflection;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;
using SwaggerEnrichers.EnricherExtractors;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerEnrichers.Filters;

internal class ParameterEnricherFilter : IParameterFilter
{
    private readonly IParameterEnricherExtractor _enricherExtractor = new EnricherExtractor();
    
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        ApplyParameter(parameter, context.ParameterInfo);
        ApplyProperty(parameter, context.PropertyInfo);
    }

    public void ApplyParameter(OpenApiParameter parameter, ParameterInfo? parameterInfo)
    {
        Enrich(parameter, parameterInfo);
    }

    public void ApplyProperty(OpenApiParameter parameter, MemberInfo? propertyInfo)
    {
        Enrich(parameter, propertyInfo);
    }

    private void Enrich(OpenApiParameter parameter, ICustomAttributeProvider? attributeProvider)
    {
        IParameterEnricher? enricher = _enricherExtractor.ExtractParameterEnricher(attributeProvider);

        enricher?.Enrich(parameter);
    }
}