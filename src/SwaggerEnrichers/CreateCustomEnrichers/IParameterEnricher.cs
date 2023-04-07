using Microsoft.OpenApi.Models;

namespace SwaggerEnrichers.CreateCustomEnrichers;

public interface IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter);
}