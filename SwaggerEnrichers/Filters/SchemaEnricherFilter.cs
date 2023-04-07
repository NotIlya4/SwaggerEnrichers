using System.Reflection;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateOwnEnrichers;
using SwaggerEnrichers.EnricherProviders;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerEnrichers.Filters;

internal class SchemaEnricherFilter : ISchemaFilter
{
    private readonly ISchemaEnricherProvider _enricherProvider = new EnricherProvider();
    
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        Enrich(schema, context.MemberInfo);
        Enrich(schema, context.ParameterInfo);
        Enrich(schema, context.Type);
    }

    private void Enrich(OpenApiSchema schema, ICustomAttributeProvider? attributeProvider)
    {
        ISchemaEnricher? enricher = _enricherProvider.GetSchemaEnricher(attributeProvider);

        enricher?.Enrich(schema);
    }
}