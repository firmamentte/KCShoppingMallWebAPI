using Microsoft.AspNetCore.Mvc;

namespace KCShoppingMallWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) : ControllerBase
{
    private readonly BLL.BLL.Product product = new(configuration);
    private readonly Helpers.Product productHelper = new();

    [Route("V1/GetProducts")]
    [HttpGet]
    public async Task<ActionResult> GetProducts([FromQuery] bool? featured)
     {
        var products = await product.GetProducts(featured);

        await productHelper.GetProductImagesBase64String(webHostEnvironment, products);

        return Ok(products);
    }
}
