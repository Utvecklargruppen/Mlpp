using Mlpp.Domain.Product.State;
using Mlpp.Infrastructure.Storage.Mlpp;
using System;
using System.Linq;

namespace Mlpp.QueryService.Product.Queries
{
    public class GetProductById : IQuery<ProductState>
    {
        private readonly Guid _id;

        public GetProductById(Guid id)
        {
            _id = id;
        }

        public ProductState Execute(IReadOnlyMlppContext context)
        {
            return context.Products.SingleOrDefault(x => x.Id == _id);
        }
    }
}
