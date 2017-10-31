using Microsoft.AspNetCore.Mvc;
using Mlpp.ApplicationService.Product;
using Mlpp.ApplicationService.Product.Command;
using Mlpp.QueryService.Product;
using System;

namespace Mlpp.Controllers
{
    [Route("api/product/{productId}/part")]
    public class ProductPartController : Controller
    {
        private readonly IProductQueryService _productQueryService;
        private readonly IProductService _productService;

        public ProductPartController(IProductService productService, IProductQueryService productQueryService)
        {
            _productService = productService;
            _productQueryService = productQueryService;
        }

        [HttpDelete("{partId}")]
        public void Delete(Guid? productId, Guid? partId)
        {
            _productService.When(new RemovePart(productId.GetValueOrDefault(), partId.GetValueOrDefault()));
        }

        [HttpGet]
        public IActionResult Get(Guid? productId)
        {
            return Ok(_productQueryService.GetProductParts(productId.GetValueOrDefault()));
        }

        [HttpGet("{partId}")]
        public IActionResult Get(Guid? productId, Guid? partId)
        {
            return Ok(_productQueryService.GetProductPart(productId.GetValueOrDefault(), partId.GetValueOrDefault()));
        }

        [HttpPost("{partId}")]
        public IActionResult Post(Guid? productId, Guid? partId)
        {
            _productService.When(new AddPart(productId.GetValueOrDefault(), partId.GetValueOrDefault()));

            return CreatedAtAction("Post", partId);
        }
    }
}