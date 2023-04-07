using System.Reflection;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace SwaggerEnrichers.EnricherExtractors;

internal class EnricherExtractor : ISchemaEnricherExtractor, IParameterEnricherExtractor
{
    private readonly AttributeExtractor _attributeExtractor = new AttributeExtractor();
    
    public IParameterEnricher? ExtractParameterEnricher(ICustomAttributeProvider? attributeProvider)
    {
        if (attributeProvider is null) return null;

        return _attributeExtractor.GetAttributeAssignableTo<IParameterEnricher>(attributeProvider);
    }

    public ISchemaEnricher? ExtractSchemaEnricher(ICustomAttributeProvider? attributeProvider)
    {
        if (attributeProvider is null) return null;
        
        return _attributeExtractor.GetAttributeAssignableTo<ISchemaEnricher>(attributeProvider);
    }
}