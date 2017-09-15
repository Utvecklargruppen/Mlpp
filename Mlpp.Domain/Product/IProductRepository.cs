using System;
using Mlpp.Domain;

namespace Mlpp.Domain.Product
{
    public interface IProductRepository :
        IReadableRepository<ProductAggregate, Guid>,
        IWriteableRepository<ProductAggregate, Guid>
    {
    }
}
