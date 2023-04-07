using SwaggerEnrichers.UnitTests.Filters.SchemaEnricherFilterTests.Enrichers;

namespace SwaggerEnrichers.UnitTests.Filters.SchemaEnricherFilterTests.TestClasses;

[ClassSchemaEnricher]
public class ClassWithSchemaEnrichers
{
    [PropertySchemaEnricher]
    public string Property { get; } = "a";

    public void Method([ParameterSchemaEnricher] string argument)
    {
        
    }
}