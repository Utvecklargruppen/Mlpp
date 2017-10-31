using Microsoft.EntityFrameworkCore;
using Mlpp.Domain.Part.State;
using Mlpp.Domain.Product.State;
using System.Linq;

namespace Mlpp.Infrastructure.Storage.Mlpp
{
    public class ReadOnlyMlppContext : IReadOnlyMlppContext
    {
        private readonly MlppContext _context;

        public ReadOnlyMlppContext(MlppContext context)
        {
            _context = context;
        }

        public IQueryable<PartState> Parts => _context.Parts.AsNoTracking();

        public IQueryable<ProductPartState> ProductParts => _context.ProductParts.AsNoTracking();

        public IQueryable<ProductState> Products => _context.Products.AsNoTracking();
    }
}