using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.UpdateClient
{
	public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
	{
		private readonly IClientRepository _clientRepository;
		public UpdateClientCommandHandler(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}
		public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
		{
			var client = await _clientRepository.GetByIdAsync(request.Id);

			client.Update(request.Name, request.LastName, request.Address, request.NumberAddress);

			await _clientRepository.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
