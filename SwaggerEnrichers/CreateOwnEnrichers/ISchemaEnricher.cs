using Microsoft.OpenApi.Models;

namespace SwaggerEnrichers.CreateOwnEnrichers;

public interface ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema);
}