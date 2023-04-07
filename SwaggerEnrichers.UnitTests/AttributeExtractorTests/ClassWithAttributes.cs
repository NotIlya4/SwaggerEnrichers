namespace SwaggerEnrichers.UnitTests.AttributeExtractorTests;

[TestAttribute2]
[TestAttribute1(Name = "1")]
[TestAttribute2]
[TestAttribute1(Name = "2")]
[TestAttribute2]
public class ClassWithAttributes
{
    
}