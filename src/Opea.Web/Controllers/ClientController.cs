using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Opea.Application.Commands;
using Opea.Application.Queries;
using Opea.Application.ViewModels;
using Opea.Domain.AggregatesModel.ClientAggregate;

namespace Opea.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ClientController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _mediator.Send(new GetAllClientQuery());

            var viewModel = _mapper.Map<IEnumerable<ClientViewModel>>(clients);

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = await _mediator.Send(new GetByIdClientQuery(id));

            if (client == null)
                return NotFound();

            return View(_mapper.Map<ClientViewModel>(client));
        }

        public IActionResult Create()
        {
            ViewData["CompanySize"] = new SelectList(CompanySize.GetAll<CompanySize>(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateClientCommand(_mapper.Map<Client>(clientViewModel)));

                return RedirectToAction(nameof(Index));
            }

            return View(clientViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _mediator.Send(new GetByIdClientQuery(id));

            if (client == null)
                return BadRequest();

            ViewData["CompanySize"] = new SelectList(CompanySize.GetAll<CompanySize>(), "Id", "Name");

            return View(_mapper.Map<ClientViewModel>(client));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateClientCommand(_mapper.Map<Client>(clientViewModel)));

                return RedirectToAction(nameof(Index));
            }

            return View(clientViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _mediator.Send(new GetByIdClientQuery(id));

            if (client == null)
                return NotFound();           

            return View(_mapper.Map<ClientViewModel>(client));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _mediator.Send(new GetByIdClientQuery(id));

            if (client == null)
                return BadRequest();

            await _mediator.Send(new DeleteClientCommand(client));            

            return RedirectToAction(nameof(Index));
        }
    }
}
