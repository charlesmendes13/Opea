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

            container.AddScoped<IRequestHandler<GetAllClientQuery, IEnumerable<Client>>, GetAllClientQueryHandler>();
            container.AddScoped<IRequestHandler<GetByIdClientQuery, Client>, GetByIdClientQueryHandler>();
            container.AddScoped<IRequestHandler<CreateClientCommand, Client>, CreateClientCommandHandler>();
            container.AddScoped<IRequestHandler<DeleteClientCommand, Client>, DeleteClientCommandHandler>();
            container.AddScoped<IRequestHandler<UpdateClientCommand, Client>, UpdateClientCommandHandler>();

            // Domain

            container.AddScoped<INotificationHandler<ClientRegisteredEvent>, ClientRegisteredEventHandler>();
            container.AddScoped<INotificationHandler<ClientRemovedEvent>, ClientRemovedEventHandler>();
            container.AddScoped<INotificationHandler<ClientUpdatedEvent>, ClientUpdatedEventHandler>();

            // Infra

            container.AddScoped<IClientRepository, ClientRepository>();
            container.AddScoped<OpeaContext>();
        }
    }
}
