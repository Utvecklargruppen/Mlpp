using AutoMapper;
using Mlpp.Domain.Product.States;
using Mlpp.Infrastructure.Storage.Mlpp;
using Mlpp.QueryService.Product.Models;
using Mlpp.QueryService.Product.Queries;
using System;
using System.Collections.Generic;

namespace Mlpp.QueryService.Product
{
    public class ProductQueryService : BaseQueryService, IProductQueryService
    {
        public ProductQueryService(IReadOnlyMlppContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public ProductModel GetProductById(Guid id)
        {
            return Execute<ProductModel, ProductState>(new GetProductById(id));
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return Execute<ProductModel, ProductState>(new GetProducts());
        }
    }
}
