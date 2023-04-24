using Buisness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllOrderBy();
            if (products.Success)
            {
                return Ok(products);

            }
            return BadRequest(products);
        }

        [HttpGet("getbyid")] /*https://localhost:44390/api/Products/getbyid?id=78* /*/
        public IActionResult GetByIdProduct(int id)
        {
            var productId = _productService.GetById(id);
            if (productId.Success)
            {
                return Ok(productId);
            }
            return BadRequest(productId);

        }

        [HttpPost("add")]
        public IActionResult AddProduct(Product product)
        {
            var prod = _productService.AddProduct(product);
            if (prod.Success)
            {
                return Ok(prod);
            }
            return BadRequest(prod);

        }
    }
}
