# SwaggerEnrichers

`SwaggerEnrichers` is a C# package that offers a more flexible and convenient way to add `ISchemaFilter` and `IParameterFilter` using attributes. While you can use the `SwaggerSchemaAttribute` from `Swashbuckle.AspNetCore.Annotations`, `SwaggerEnrichers` allows you to configure example values, value type and so on.

## How it works

`SwaggerEnrichers` comprises an `ISchemaFilter` and an `IParameterFilter` that analyze incoming classes, parameters, and properties. The filters look for attributes that implement `IParameterEnricher` or `ISchemaEnricher`, once they find these attributes, they use their Enrich methods to modify the schema or parameter.

## Getting started

To get started with `SwaggerEnrichers`, you need to add the necessary filters to `SwaggerGen`:
```csharp
builder.Services.AddSwaggerGen(options =>
{
    options.AddEnricherFilters();
});
```

After that, you need to create an attribute that implements `ISchemaFilter` or `IParameterFilter`. You can create an attribute that implements both as well:

```csharp
public class ProductViewIdAttribute : Attribute, ISchemaEnricher, IParameterEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Title = "Product Id";
        schema.Description = "Product identifier";
        schema.Example = new OpenApiInteger(3);
    }

    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Product Id";
        parameter.Description = "Product identifier";
        parameter.Schema.Example = null;
    }
}

public class ProductViewNameAttribute : Attribute, ISchemaEnricher, IParameterEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Title = "Product Name";
        schema.Description = "Name of product";
        schema.Example = new OpenApiString("Apple Watch");
    }

    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Name = "Product Name";
        parameter.Description = "Name of product";
        parameter.Schema.Example = null;
    }
}
```

Now, you can apply these attributes to any `class`, `parameter`, `property`, or `member`:

```csharp
public class ProductView
{
    [ProductViewId]
    public required int Id { get; init; }
    [ProductViewName]
    public required string Name { get; init; }
    [ProductViewPrice]
    public required decimal Price { get; init; }
    [ProductViewType]
    public required string Type { get; init; }
}

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    [Route("id/{id}")]
    public ActionResult<ProductView> GetProductById([ProductViewId] string id)
    {
        return Ok();
    }
    
    [HttpGet]
    [Route("name/{name}")]
    public ActionResult<ProductView> GetProductByName([ProductViewName] string name)
    {
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<ProductView>> GetProducts([FromQuery] GetProductsQueryView getProductsQueryView)
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult PostProduct(ProductView productView)
    {
        return NoContent();
    }
}
```

For more complex examples see `Demo` project