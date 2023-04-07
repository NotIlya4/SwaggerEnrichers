using System.Reflection;
using SwaggerEnrichers.CreateOwnEnrichers;

namespace SwaggerEnrichers.EnricherProviders;

internal interface ISchemaEnricherProvider
{
    public ISchemaEnricher? GetSchemaEnricher(ICustomAttributeProvider? attributeProvider);
}