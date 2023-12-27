using Clientes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infrastructure.Persistence
{
	public class ClientDbContext : DbContext
	{
		public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }

		public DbSet<Client> Clients { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
