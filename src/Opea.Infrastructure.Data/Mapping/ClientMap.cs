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

            builder.Property(b => b.CompanyName);
            builder.Property(b => b.CompanySizeId);
            builder.Ignore(b => b.CompanySize);

            builder.Ignore(b => b.DomainEvents);
        }
    }
}
