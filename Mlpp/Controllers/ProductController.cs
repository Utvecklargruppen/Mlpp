using Microsoft.AspNetCore.Mvc;
using Mlpp.ApplicationService.Product;
using Mlpp.ApplicationService.Product.Command;
using Mlpp.QueryService.Product;
using System;
using Microsoft.EntityFrameworkCore;
using Mlpp.Domain.Product.States;
using Mlpp.Infrastructure.Storage.Mlpp;

namespace Mlpp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductQueryService _productQueryService;
        private readonly MlppContext _context;

        public ProductController(MlppContext context, IProductService productService, IProductQueryService productQuerytService)
        {
            _productService = productService;
            _productQueryService = productQuerytService;
            _context = context;
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
            //_context.Products.Add(new ProductState { Id = id, Name = "hejhopp"});
            //_context.SetEntityState(new ProductState { Id = id, Name = "hejhopp" }, EntityState.Added);
            _context.SaveChanges();
            return CreatedAtAction("Post", id);
        }

        [HttpPut("{id}")]
        public void Put(Guid? id, [FromBody]string name)
        {
            _productService.When(new ChangeProductName(id.GetValueOrDefault(), name));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
