namespace SwaggerEnrichers.UnitTests.EnricherExtractors;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class TestAttribute1Attribute : Attribute
{
    public required string Name { get; init; }
}