using System.Reflection;
using SwaggerEnrichers.CreateOwnEnrichers;

namespace SwaggerEnrichers.EnricherProviders;

internal interface IParameterEnricherProvider
{
    public IParameterEnricher? GetParameterEnricher(ICustomAttributeProvider? attributeProvider);
}