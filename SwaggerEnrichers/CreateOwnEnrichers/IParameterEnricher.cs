using Microsoft.OpenApi.Models;

namespace SwaggerEnrichers.CreateOwnEnrichers;

public interface IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter);
}