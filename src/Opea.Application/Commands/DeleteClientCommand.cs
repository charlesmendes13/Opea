﻿using MediatR;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Application.Commands
{
    public class DeleteClientCommand : IRequest<Client>
    {
        public Client Client { get; private set; }

        public DeleteClientCommand(Client client)
        {
            Client = client;
        }
    }
}
