using Microsoft.EntityFrameworkCore;
using Mlpp.Domain.Product.States;

namespace Mlpp.Infrastructure.Storage.Mlpp
{
    public class MlppContext : DbContext, IContext
    {
        public MlppContext(DbContextOptions<MlppContext> options) : base(options)
        {
        }

        public DbSet<ProductState> Products { get; set; }

        public void SetEntityState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        public EntityState GetEntityState(object entity)
        {
            return Entry(entity).State;
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}