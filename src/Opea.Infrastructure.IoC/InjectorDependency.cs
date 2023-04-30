using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Opea.Application.Commands;
using Opea.Application.EventHandlers;
using Opea.Application.Queries;
using Opea.Domain.AggregatesModel.ClientAggregate;
using Opea.Domain.Events;
using Opea.Infrastructure.Data.Context;
using Opea.Infrastructure.Data.Repository;

namespace Opea.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Application

            container.AddTransient<IRequestHandler<GetAllClientQuery, IEnumerable<Client>>, GetAllClientQueryHandler>();
            container.AddTransient<IRequestHandler<GetByIdClientQuery, Client>, GetByIdClientQueryHandler>();
            container.AddTransient<IRequestHandler<CreateClientCommand, Client>, CreateClientCommandHandler>();
            container.AddTransient<IRequestHandler<DeleteClientCommand, Client>, DeleteClientCommandHandler>();
            container.AddTransient<IRequestHandler<UpdateClientCommand, Client>, UpdateClientCommandHandler>();

            // Domain

            container.AddTransient<INotificationHandler<ClientRegisteredEvent>, ClientRegisteredEventHandler>();
            container.AddTransient<INotificationHandler<ClientRemovedEvent>, ClientRemovedEventHandler>();
            container.AddTransient<INotificationHandler<ClientUpdatedEvent>, ClientUpdatedEventHandler>();

            // Infra

            container.AddTransient<OpeaContext>();
            container.AddTransient<IClientRepository, ClientRepository>();
        }
    }
}
