using System.Linq;
using Mlpp.Domain.Part.State;
using Mlpp.Domain.Product.State;

namespace Mlpp.Infrastructure.Storage.Mlpp
{
    public interface IReadOnlyMlppContext
    {
        IQueryable<ProductState> Products { get; }
        IQueryable<PartState> Parts { get; }
        IQueryable<ProductPartState> ProductParts { get; }
    }
}
