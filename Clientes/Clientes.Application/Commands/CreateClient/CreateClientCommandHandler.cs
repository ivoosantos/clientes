using Clientes.Application.Validators;
using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.CreateClient
{
	public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
	{
		private readonly IClientRepository _clientRepository;
		public CreateClientCommandHandler(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}
		public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
		{
			var client = new Client(request.Name, request.LastName, request.DateOfBirth, request.Rg, request.Cpf, request.Address, request.NumberAddress);

			await _clientRepository.AddAsync(client);

			return client.Id;
		}
	}
}
