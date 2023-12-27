using Clientes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Repositories
{
	public interface IClientRepository
	{
		Task AddAsync(Client client);
		Task<List<Client>> GetAllAsync();
		Task<Client> GetByIdAsync(int id);
		Task<bool> CustomerExists(string cpf);
		Task SaveChangesAsync();
	}
}
