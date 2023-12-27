using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.CreateClient
{
	public class CreateClientCommand : IRequest<int>
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Rg { get; set; }
		public string Cpf { get; set; }
		public string Address { get; set; }
		public string NumberAddress { get; set; }
	}
}
