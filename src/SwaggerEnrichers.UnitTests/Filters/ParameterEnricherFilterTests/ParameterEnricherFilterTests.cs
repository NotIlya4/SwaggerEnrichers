using System.Reflection;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.Filters;
using SwaggerEnrichers.UnitTests.Filters.ParameterEnricherFilterTests.TestClasses;

namespace SwaggerEnrichers.UnitTests.Filters.ParameterEnricherFilterTests;

public class ParameterEnricherFilterTests
{
    internal ParameterEnricherFilter Filter { get; }
    
    public OpenApiParameter ParameterParameter { get; }
    public OpenApiParameter PropertyParameter { get; }

    public ParameterInfo ParameterInfoWithEnricher { get; }
    public ParameterInfo ParameterInfoWithoutEnricher { get; }
    
    public MemberInfo PropertyInfoWithEnricher { get; }
    public MemberInfo PropertyInfoWithoutEnricher { get; }
    
    public ParameterEnricherFilterTests()
    {
        Filter = new ParameterEnricherFilter();

        ParameterParameter = new OpenApiParameter();
        PropertyParameter = new OpenApiParameter();
        ParameterParameter.Name = "None";
        PropertyParameter.Name = "None";

        ParameterInfoWithEnricher =
            typeof(ClassWithParameterEnrichers).GetMethod(nameof(ClassWithParameterEnrichers.Method))!.GetParameters()[0];
        ParameterInfoWithoutEnricher =
            typeof(ClassWithoutParameterEnrichers).GetMethod(nameof(ClassWithoutParameterEnrichers.Method))!.GetParameters()[0];;

        PropertyInfoWithEnricher =
            typeof(ClassWithParameterEnrichers).GetMember(nameof(ClassWithParameterEnrichers.Property))[0];
        PropertyInfoWithoutEnricher =
            typeof(ClassWithoutParameterEnrichers).GetMember(nameof(ClassWithoutParameterEnrichers.Property))[0];
    }

    [Fact]
    public void Apply_ClassWithoutEnrichers_NoChangesParameter()
    {
        Filter.ApplyParameter(ParameterParameter, ParameterInfoWithoutEnricher);
        Filter.ApplyProperty(PropertyParameter, PropertyInfoWithoutEnricher);
        
        Assert.Equal("None", ParameterParameter.Name);
        Assert.Equal("None", PropertyParameter.Name);
    }

    [Fact]
    public void Apply_ClassWithEnrichers_EnricherAlterParameter()
    {
        Filter.ApplyParameter(ParameterParameter, ParameterInfoWithEnricher);
        Filter.ApplyProperty(PropertyParameter, PropertyInfoWithEnricher);
        
        Assert.Equal("Parameter", ParameterParameter.Name);
        Assert.Equal("Property", PropertyParameter.Name);
    }
}