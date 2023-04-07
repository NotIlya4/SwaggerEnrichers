using SwaggerEnrichers.UnitTests.Filters.ParameterEnricherFilterTests.Enrichers;

namespace SwaggerEnrichers.UnitTests.Filters.ParameterEnricherFilterTests.TestClasses;

public class ClassWithParameterEnrichers
{
    [PropertyParameterEnricher]
    public string Property { get; } = "a";

    public void Method([ParameterParameterEnricher] string argument)
    {
        
    }
}