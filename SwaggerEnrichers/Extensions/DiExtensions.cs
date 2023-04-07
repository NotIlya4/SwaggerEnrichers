using Microsoft.Extensions.DependencyInjection;
using SwaggerEnrichers.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerEnrichers.Extensions;

public static class DiExtensions
{
    public static void AddEnricherFilters(this SwaggerGenOptions options)
    {
        options.ParameterFilter<ParameterEnricherFilter>();
        options.SchemaFilter<SchemaEnricherFilter>();
    }
}