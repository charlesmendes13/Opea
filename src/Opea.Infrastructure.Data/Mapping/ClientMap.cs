using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Infrastructure.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(b => b.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(b => b.CompanyName);

            builder.Property<int>("_companySizeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CompanySize")
                .IsRequired();

            builder.HasOne(p => p.CompanySize)
                .WithMany()
                .HasForeignKey("_companySizeId");
        }
    }
}
