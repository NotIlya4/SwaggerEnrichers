using SwaggerEnrichers.UnitTests.Filters.ParameterEnricherFilterTests.Enrichers;

namespace SwaggerEnrichers.UnitTests.Filters.ParameterEnricherFilterTests.TestClasses;

public class ClassWithoutParameterEnrichers
{
    public string Property { get; } = "a";

    public void Method(string argument)
    {
        
    }
}