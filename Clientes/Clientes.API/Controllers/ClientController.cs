using Clientes.Application.Commands.CreateClient;
using Clientes.Application.Commands.DeleteClient;
using Clientes.Application.Queries;
using Clientes.Application.Queries.GetAllClients;
using Clientes.Application.Queries.GetClientById;
using Clientes.Application.Queries.UpdateClient;
using Clientes.Application.Validators;
using Clientes.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.API.Controllers
{
	[Route("api/clients")]
	public class ClientController : ControllerBase
	{
		private readonly IClientRepository _clientRepository;
		private readonly IMediator _mediator;
		public ClientController(IMediator mediator, IClientRepository clientRepository)
		{
			_mediator = mediator;
			_clientRepository = clientRepository;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]CreateClientCommand command)
		{
			var cpfIsValid = ValidationCpf.IsCpf(command.Cpf);

			if (!cpfIsValid)
			{
				return BadRequest("CPF é inválido!");
			}

			var customerExists = await _clientRepository.CustomerExists(command.Cpf);

			if (customerExists)
				return BadRequest("Cliente já existe");

			var id = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = id }, command);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] UpdateClientCommand command)
		{
			command.Id = id;

			await _mediator.Send(command);

			return NoContent();
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{

			var command = new GetAllClientsQuery();

			var projects = await _mediator.Send(command);

			return Ok(projects);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var query = new GetClientByIdQuery(id);

			var resp = await _mediator.Send(query);

			if (resp == null) return NotFound();

			return Ok(resp);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			//_projectService.Delete(id);
			var command = new DeleteClientCommand(id);
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
