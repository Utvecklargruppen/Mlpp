using Microsoft.AspNetCore.Mvc;
using Mlpp.ApplicationService.Product;
using Mlpp.ApplicationService.Product.Command;
using Mlpp.QueryService.Product;
using System;

namespace Mlpp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductQueryService _productQueryService;

        public ProductController(IProductService productService, IProductQueryService productQuerytService)
        {
            _productService = productService;
            _productQueryService = productQuerytService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productQueryService.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid? id)
        {
            return Ok(_productQueryService.GetProductById(id.GetValueOrDefault()));
        }

        [HttpPost]
        public IActionResult Post([FromBody]string name)
        {
            var id = Guid.NewGuid();

            _productService.When(new CreateProduct(id, name));

            return CreatedAtAction("Post", id);
        }

        [HttpPut("{id}")]
        public void Put(Guid? id, [FromBody]string name)
        {
            _productService.When(new ChangeProductName(id.GetValueOrDefault(), name));
        }

        [HttpDelete("{id}")]
        public void Delete(Guid? id)
        {
            _productService.When(new RemoveProduct(id.GetValueOrDefault()));
        }
    }
}
