using SwaggerEnrichers.Demo.Enrichers;

namespace SwaggerEnrichers.Demo.Controllers;

public class GetProductsQueryView
{
    [GetProductsQueryViewMinPrice]
    public decimal? MinPrice { get; init; }
    [GetProductsQueryViewMaxPrice]
    public decimal? MaxPrice { get; init; }
}
