using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opea.Application.Commands;
using Opea.Application.Queries;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;
using System.Net;

namespace Opea.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ClientController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientViewModel>>> Get()
        {
            var clients = await _mediator.Send(new GetAllClientQuery());

            return Ok(_mapper.Map<IEnumerable<ClientViewModel>>(clients));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ClientViewModel>> Get(int id)
        {
            var client = await _mediator.Send(new GetByIdClientQuery(id));

            if (client == null)
                return NotFound();

            return Ok(_mapper.Map<ClientViewModel>(client));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClientViewModel>> Post(ClientViewModel clientViewModel)
        {
            var client = await _mediator.Send(new CreateClientCommand(_mapper.Map<Client>(clientViewModel)));

            return Ok(_mapper.Map<ClientViewModel>(client));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ClientViewModel>> Put(ClientViewModel clientViewModel)
        {
            var client = await _mediator.Send(new UpdateClientCommand(_mapper.Map<Client>(clientViewModel)));

            if (client == null)
                return BadRequest();

            return Ok(_mapper.Map<ClientViewModel>(client));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ClientViewModel>> Delete(int id)
        {
            var client = await _mediator.Send(new GetByIdClientQuery(id));

            if (client == null)
                return NotFound();

            await _mediator.Send(new DeleteClientCommand(client));

            if (client == null)
                return BadRequest();

            return Ok(_mapper.Map<ClientViewModel>(client));
        }
    }
}
