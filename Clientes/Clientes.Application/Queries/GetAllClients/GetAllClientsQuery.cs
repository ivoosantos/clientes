using Clientes.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetAllClients
{
	public class GetAllClientsQuery : IRequest<List<ClientDetailsViewModel>>
	{
		public GetAllClientsQuery() { }
	}
}
