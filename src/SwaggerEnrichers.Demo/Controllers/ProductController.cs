using Microsoft.AspNetCore.Mvc;
using SwaggerEnrichers.Demo.Enrichers;

namespace SwaggerEnrichers.Demo.Controllers;

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