using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mlpp.Domain.Product.States;

namespace Mlpp.Infrastructure.Storage.Mlpp
{
    public class ReadOnlyMlppContext : IReadOnlyMlppContext
    {
        private readonly MlppContext _context;

        public ReadOnlyMlppContext(MlppContext context)
        {
            _context = context;
        }

        public IQueryable<ProductState> Products => _context.Products.AsNoTracking();
    }
}
