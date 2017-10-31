using System;
using System.Collections.Generic;
using Mlpp.QueryService.Product.Models;

namespace Mlpp.QueryService.Product
{
    public interface IProductQueryService
    {
        ProductModel GetProductById(Guid id);
        IEnumerable<ProductModel> GetProducts();
        IEnumerable<PartModel> GetProductPart(Guid productId, Guid partId);
        IEnumerable<PartModel> GetProductParts(Guid productId);
    }
}
