using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.DeleteClient
{
	public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
	{
		private readonly IClientRepository _clientRepository;
		public DeleteClientCommandHandler(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}
		public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
		{
			var client = await _clientRepository.GetByIdAsync(request.Id);

			client.Status(false);

			await _clientRepository.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
