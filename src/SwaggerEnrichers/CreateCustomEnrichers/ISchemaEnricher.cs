using Microsoft.OpenApi.Models;

namespace SwaggerEnrichers.CreateCustomEnrichers;

public interface ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema);
}