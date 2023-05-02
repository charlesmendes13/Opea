using MediatR;
using Microsoft.EntityFrameworkCore;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Commom;
using Opea.Infrastructure.Data.Mapping;

namespace Opea.Infrastructure.Data.Context
{
    public class OpeaContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public DbSet<Client> Client { get; set; }
        public DbSet<CompanySize> CompanySize { get; set; }

        public OpeaContext(DbContextOptions<OpeaContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new CompanySizeMap());

            modelBuilder.Entity<CompanySize>().HasData(
                new CompanySize(1, "Small"),
                new CompanySize(2, "Medium"),
                new CompanySize(3, "Large")
                );
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }        
    }

    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, OpeaContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
