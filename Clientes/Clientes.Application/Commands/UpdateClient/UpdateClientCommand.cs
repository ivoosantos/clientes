using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.UpdateClient
{
	public class UpdateClientCommand : IRequest<Unit>
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string NumberAddress { get; set; }
	}
}
