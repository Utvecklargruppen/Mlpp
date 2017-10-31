using Mlpp.Domain.Product;
using Mlpp.Domain.Product.State;
using System;

namespace Mlpp.Infrastructure.Storage.Mlpp.Repository
{
    public class ProductRepository :
        GenericRepository<MlppContext, ProductAggregate, ProductState, Guid>,
        IProductRepository
    {
        public ProductRepository(MlppContext context, IAggregateFactory aggregateFactory)
            : base(context, aggregateFactory)
        {
        }
    }
}