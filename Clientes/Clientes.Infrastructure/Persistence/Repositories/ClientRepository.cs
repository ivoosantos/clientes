using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infrastructure.Persistence.Repositories
{
	public class ClientRepository : IClientRepository
	{
		private readonly ClientDbContext _dbContext;
		private readonly string _connectionString;
		public ClientRepository(ClientDbContext dbContext, IConfiguration connectionString)
		{
			_dbContext = dbContext;
			_connectionString = connectionString.GetConnectionString("Client");
		}

		public async Task AddAsync(Client client)
		{
			await _dbContext.Clients.AddAsync(client);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Client>> GetAllAsync()
		{
			return await _dbContext.Clients.ToListAsync();
		}

		public async Task<Client> GetByIdAsync(int id)
		{
			return await _dbContext.Clients.SingleOrDefaultAsync(c => c.Id == id);
		}

		public async Task<bool> CustomerExists(string cpf)
		{
			var customer = await _dbContext.Clients.SingleOrDefaultAsync(c => c.Cpf == cpf);

			if(customer == null)
				return false;

			return true;
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
