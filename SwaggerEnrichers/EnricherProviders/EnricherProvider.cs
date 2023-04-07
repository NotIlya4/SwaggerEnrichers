using System.Reflection;
using SwaggerEnrichers.CreateOwnEnrichers;

namespace SwaggerEnrichers.EnricherProviders;

internal class EnricherProvider : ISchemaEnricherProvider, IParameterEnricherProvider
{
    private readonly AttributeExtractor _attributeExtractor = new AttributeExtractor();
    
    public IParameterEnricher? GetParameterEnricher(ICustomAttributeProvider? attributeProvider)
    {
        if (attributeProvider is null) return null;

        return _attributeExtractor.GetAttributeAssignableTo<IParameterEnricher>(attributeProvider);
    }

    public ISchemaEnricher? GetSchemaEnricher(ICustomAttributeProvider? attributeProvider)
    {
        if (attributeProvider is null) return null;
        
        return _attributeExtractor.GetAttributeAssignableTo<ISchemaEnricher>(attributeProvider);
    }
}