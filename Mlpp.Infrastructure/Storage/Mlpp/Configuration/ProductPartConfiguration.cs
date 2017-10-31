using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mlpp.Domain.Product.State;

namespace Mlpp.Infrastructure.Storage.Mlpp.Configuration
{
    public class ProductPartConfiguration : IEntityTypeConfiguration<ProductPartState>
    {
        public void Configure(EntityTypeBuilder<ProductPartState> builder)
        {
            builder.ToTable("ProductParts");

            builder.HasKey(x => new { x.ProductId, x.PartId });

            builder.HasOne(x => x.Product).WithMany(x => x.Parts).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Part).WithMany(x => x.Products).HasForeignKey(x => x.PartId);
        }
    }
}
