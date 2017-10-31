using Mlpp.Domain.Part.State;
using Mlpp.Infrastructure.Storage.Mlpp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mlpp.QueryService.Product.Queries
{
    public class GetProductPart : IQuery<IEnumerable<PartState>>
    {
        private readonly Guid _partId;
        private readonly Guid _productId;

        public GetProductPart(Guid productId, Guid partId)
        {
            _productId = productId;
            _partId = partId;
        }

        public IEnumerable<PartState> Execute(IReadOnlyMlppContext context)
        {
            return context.ProductParts
                .Where(x => x.ProductId == _productId && x.PartId == _partId)
                .Select(x => x.Part);
        }
    }
}