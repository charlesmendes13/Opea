using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Infrastructure.Data.Mapping
{
    public class CompanySizeMap : IEntityTypeConfiguration<CompanySize>
    {
        public void Configure(EntityTypeBuilder<CompanySize> builder)
        {
            builder.ToTable("CompanySize");

            builder.HasKey(b => b.Id);

            builder.Property(ct => ct.Id)
           .HasDefaultValue(1)
           .ValueGeneratedNever()
           .IsRequired();

            builder.Property(ct => ct.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
