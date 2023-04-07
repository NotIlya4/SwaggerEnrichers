using System.Reflection;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.EnricherExtractors;

internal interface ISchemaEnricherExtractor
{
    public ISchemaEnricher? ExtractSchemaEnricher(ICustomAttributeProvider? attributeProvider);
}