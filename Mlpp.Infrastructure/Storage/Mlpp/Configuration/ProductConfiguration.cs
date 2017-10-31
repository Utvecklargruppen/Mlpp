using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mlpp.Domain.Product.State;

namespace Mlpp.Infrastructure.Storage.Mlpp.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductState>
    {
        public void Configure(EntityTypeBuilder<ProductState> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Parts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}