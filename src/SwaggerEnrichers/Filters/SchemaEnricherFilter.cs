using System.Reflection;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;
using SwaggerEnrichers.EnricherExtractors;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerEnrichers.Filters;

internal class SchemaEnricherFilter : ISchemaFilter
{
    private readonly ISchemaEnricherExtractor _enricherExtractor = new EnricherExtractor();
    
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        ApplyClass(schema, context.Type);
        ApplyParameter(schema, context.ParameterInfo);
        ApplyProperty(schema, context.MemberInfo);
    }

    public void ApplyClass(OpenApiSchema schema, Type? classInfo)
    {
        Enrich(schema, classInfo);
    }
    
    public void ApplyParameter(OpenApiSchema schema, ParameterInfo? parameterInfo)
    {
        Enrich(schema, parameterInfo);
    }
    
    public void ApplyProperty(OpenApiSchema schema, MemberInfo? propertyInfo)
    {
        Enrich(schema, propertyInfo);
    }

    private void Enrich(OpenApiSchema schema, ICustomAttributeProvider? attributeProvider)
    {
        ISchemaEnricher? enricher = _enricherExtractor.ExtractSchemaEnricher(attributeProvider);

        enricher?.Enrich(schema);
    }
}