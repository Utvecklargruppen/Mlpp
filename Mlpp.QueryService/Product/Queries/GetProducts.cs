using Mlpp.Domain.Product.States;
using Mlpp.Infrastructure.Storage.Mlpp;
using System.Collections.Generic;
using System.Linq;

namespace Mlpp.QueryService.Product.Queries
{
    public class GetProducts : IQuery<IEnumerable<ProductState>>
    {
        public IEnumerable<ProductState> Execute(IReadOnlyMlppContext context)
        {
            return context.Products.ToList();
        }
    }
}
