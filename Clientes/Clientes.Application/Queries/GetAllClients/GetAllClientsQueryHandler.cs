using Clientes.Application.ViewModels;
using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetAllClients
{
	public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClientDetailsViewModel>>
	{
		private readonly IClientRepository _clientRepository;
		public GetAllClientsQueryHandler(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}
		public async Task<List<ClientDetailsViewModel>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
		{
			var clients = await _clientRepository.GetAllAsync();

			var clientsViewModel = clients.Select(c => new ClientDetailsViewModel(c.Name, c.LastName, c.DateOfBirth, c.Rg, c.Cpf, c.Address, c.NumberAddress))
				.ToList();

			return clientsViewModel;
		}
	}
}
