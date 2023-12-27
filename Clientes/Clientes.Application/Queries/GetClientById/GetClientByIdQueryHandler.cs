using Clientes.Application.ViewModels;
using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDetailsViewModel>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientByIdQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientDetailsViewModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client == null)
                return null;

            var clientDetails = new ClientDetailsViewModel(
                client.Name,
                client.LastName,
                client.DateOfBirth,
                client.Rg,
                client.Cpf,
                client.Address,
                client.NumberAddress
                );

            return clientDetails;
        }
    }
}
