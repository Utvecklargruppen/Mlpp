using Mlpp.Domain.Part.State;
using Mlpp.Infrastructure.Storage.Mlpp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mlpp.QueryService.Product.Queries
{
    public class GetProductParts : IQuery<IEnumerable<PartState>>
    {
        private readonly Guid _productId;

        public GetProductParts(Guid productId)
        {
            _productId = productId;
        }

        public IEnumerable<PartState> Execute(IReadOnlyMlppContext context)
        {
            return context.ProductParts
                .Where(x => x.ProductId == _productId)
                .Select(x => x.Part)
                .ToList();
        }
    }
}