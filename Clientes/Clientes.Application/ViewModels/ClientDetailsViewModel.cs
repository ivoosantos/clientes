using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.ViewModels
{
	public class ClientDetailsViewModel
	{
		public ClientDetailsViewModel(string name, string lastName, DateTime dateOfBirth, string rg, string cpf, string address, string numberAddress)
		{
			Name = name;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			Rg = rg;
			Cpf = cpf;
			Address = address;
			NumberAddress = numberAddress;
		}

		public string Name { get; private set; }
		public string LastName { get; private set; }
		public DateTime DateOfBirth { get; private set; }
		public string Rg { get; private set; }
		public string Cpf { get; private set; }
		public string Address { get; private set; }
		public string NumberAddress { get; private set; }
	}
}
