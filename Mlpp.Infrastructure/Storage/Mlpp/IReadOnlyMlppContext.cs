using System.Linq;
using Mlpp.Domain.Product.States;

namespace Mlpp.Infrastructure.Storage.Mlpp
{
    public interface IReadOnlyMlppContext
    {
        IQueryable<ProductState> Products { get; }
    }
}
