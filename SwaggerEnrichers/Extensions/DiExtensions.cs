﻿using Api.Swagger.EnricherSystem.Filters;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.EnricherSystem.Extensions;

public static class DiExtensions
{
    public static void AddEnricherFilters(this SwaggerGenOptions options)
    {
        options.ParameterFilter<ParameterEnricherFilter>();
        options.SchemaFilter<SchemaEnricherFilter>();
    }
}