using Microsoft.EntityFrameworkCore;
using Mlpp.Domain.Part.State;
using Mlpp.Domain.Product.State;
using Mlpp.Infrastructure.Storage.Mlpp.Configuration;

namespace Mlpp.Infrastructure.Storage.Mlpp
{
    public class MlppContext : DbContext, IContext
    {
        public MlppContext(DbContextOptions<MlppContext> options) : base(options)
        {
        }

        public DbSet<PartState> Parts { get; set; }

        public DbSet<ProductPartState> ProductParts { get; set; }

        public DbSet<ProductState> Products { get; set; }

        public EntityState GetEntityState(object entity)
        {
            return Entry(entity).State;
        }

        public void SetEntityState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PartConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPartConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}