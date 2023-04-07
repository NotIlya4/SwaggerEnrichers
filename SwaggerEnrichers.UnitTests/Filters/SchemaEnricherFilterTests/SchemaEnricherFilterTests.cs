using System.Reflection;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.Filters;
using SwaggerEnrichers.UnitTests.Filters.SchemaEnricherFilterTests.TestClasses;

namespace SwaggerEnrichers.UnitTests.Filters.SchemaEnricherFilterTests;

public class SchemaEnricherFilterTests
{
    internal SchemaEnricherFilter Filter { get; }
    
    public OpenApiSchema ClassSchema { get; }
    public OpenApiSchema ParameterSchema { get; }
    public OpenApiSchema PropertySchema { get; }

    public Type ClassInfoWithEnricher { get; }
    public Type ClassInfoWithoutEnricher { get; }

    public ParameterInfo ParameterInfoWithEnricher { get; }
    public ParameterInfo ParameterInfoWithoutEnricher { get; }

    public MemberInfo PropertyInfoWithEnricher { get; }
    public MemberInfo PropertyInfoWithoutEnricher { get; }
    
    public SchemaEnricherFilterTests()
    {
        Filter = new SchemaEnricherFilter();
        
        ClassSchema = new OpenApiSchema();
        ParameterSchema = new OpenApiSchema();
        PropertySchema = new OpenApiSchema();
        ClassSchema.Title = "None";
        ParameterSchema.Title = "None";
        PropertySchema.Title = "None";


        ClassInfoWithEnricher = typeof(ClassWithSchemaEnrichers);
        ClassInfoWithoutEnricher = typeof(ClassWithoutSchemaEnrichers);

        ParameterInfoWithEnricher = typeof(ClassWithSchemaEnrichers).GetMethod(nameof(ClassWithSchemaEnrichers.Method))!.GetParameters()[0];
        ParameterInfoWithoutEnricher = typeof(ClassWithoutSchemaEnrichers).GetMethod(nameof(ClassWithoutSchemaEnrichers.Method))!.GetParameters()[0];

        PropertyInfoWithEnricher = typeof(ClassWithSchemaEnrichers).GetMember(nameof(ClassWithSchemaEnrichers.Property))[0];
        PropertyInfoWithoutEnricher = typeof(ClassWithoutSchemaEnrichers).GetMember(nameof(ClassWithoutSchemaEnrichers.Property))[0];
    }

    [Fact]
    public void Apply_ClassWithoutEnrichers_NoChangesSchema()
    {
        Filter.ApplyClass(ClassSchema, ClassInfoWithoutEnricher);
        Filter.ApplyParameter(ParameterSchema, ParameterInfoWithoutEnricher);
        Filter.ApplyProperty(PropertySchema, PropertyInfoWithoutEnricher);
        
        Assert.Equal("None", ClassSchema.Title);
        Assert.Equal("None", ParameterSchema.Title);
        Assert.Equal("None", PropertySchema.Title);
    }

    [Fact]
    public void Apply_ClassWithEnricher_EnricherAlterSchema()
    {
        Filter.ApplyClass(ClassSchema, ClassInfoWithEnricher);
        Filter.ApplyParameter(ParameterSchema, ParameterInfoWithEnricher);
        Filter.ApplyProperty(PropertySchema, PropertyInfoWithEnricher);
        
        Assert.Equal("Class", ClassSchema.Title);
        Assert.Equal("Parameter", ParameterSchema.Title);
        Assert.Equal("Property", PropertySchema.Title);
    }
}