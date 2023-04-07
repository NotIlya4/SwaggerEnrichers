using SwaggerEnrichers.Demo.Enrichers;

namespace SwaggerEnrichers.Demo.Controllers;


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