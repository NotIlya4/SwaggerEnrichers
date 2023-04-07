using System.Reflection;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.EnricherExtractors;

internal interface IParameterEnricherExtractor
{
    public IParameterEnricher? ExtractParameterEnricher(ICustomAttributeProvider? attributeProvider);
}