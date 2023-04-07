using SwaggerEnrichers.Filters;

namespace SwaggerEnrichers.UnitTests.AttributeExtractorTests;

public class AttributeExtractorTests
{
    internal AttributeExtractor AttributeExtractor { get; }
    
    public AttributeExtractorTests()
    {
        AttributeExtractor = new AttributeExtractor();
    }

    [Fact]
    public void GetAttributeAssignableTo_ClassWithDesiredAttributeAfterAnotherAttribute_DesiredAttribute()
    {
        TestAttribute1Attribute? attribute =
            AttributeExtractor.GetAttributeAssignableTo<TestAttribute1Attribute>(typeof(ClassWithAttributes));
        
        Assert.NotNull(attribute);
        Assert.Equal("1", attribute.Name);
    }

    [Fact]
    public void GetAttributeAssignableTo_ClassDoesNotHasDesiredAttribute_ReturnNull()
    {
        SerializableAttribute? attribute =
            AttributeExtractor.GetAttributeAssignableTo<SerializableAttribute>(typeof(ClassWithAttributes));
        
        Assert.Null(attribute);
    }
}