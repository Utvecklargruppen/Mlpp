using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mlpp.Domain.Part.State;

namespace Mlpp.Infrastructure.Storage.Mlpp.Configuration
{
    public class PartConfiguration : IEntityTypeConfiguration<PartState>
    {
        public void Configure(EntityTypeBuilder<PartState> builder)
        {
            builder.ToTable("Parts");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.Part)
                .HasForeignKey(x => x.PartId);
        }
    }
}
