using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

            return View(_mapper.Map<IEnumerable<ClientViewModel>>(clients));
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(_mapper.Map<CreateClientCommand>(request));

                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _mediator.Send(new GetByIdClientQuery(id));

            if (client == null)
                return NotFound();

            return View(_mapper.Map<ClientViewModel>(client));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientViewModel request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(_mapper.Map<UpdateClientCommand>(request));

                return RedirectToAction(nameof(Index));
            }

            return View(request);
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
            await _mediator.Send(new DeleteClientCommand(id));            

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetCompanySize()
        {
            var companySize = CompanySize.GetAll<CompanySize>();
            
            return Json(_mapper.Map<IEnumerable<CompanySizeViewModel>>(companySize));
        }
    }
}
