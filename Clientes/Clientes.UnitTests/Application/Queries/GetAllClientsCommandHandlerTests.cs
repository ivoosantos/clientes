using Clientes.Application.Queries.GetAllClients;
using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.UnitTests.Application.Queries
{
	public class GetAllClientsCommandHandlerTests
	{
		[Fact]
		public async Task ThreeClientsExist_Executed_ReturnThreeClientsViewModels()
		{
			var clients = new List<Client>
			{
				new Client("Nome 1", "Sobrenome 1", new DateTime(2005, 05, 20), "123456789", "11422536945", "Rua dois", "45"),
				new Client("Nome 2", "Sobrenome 2", new DateTime(2005, 05, 15), "123456712", "11422536978", "Rua dois", "47"),
				new Client("Nome 3", "Sobrenome 3", new DateTime(2005, 05, 25), "123456745", "11422536936", "Rua dois", "49")
			};

			var clientRepositoryMock = new Mock<IClientRepository>();

			clientRepositoryMock.Setup(c => c.GetAllAsync().Result).Returns(clients);

			var getAllClientQuery = new GetAllClientsQuery();

			var getAllClientQueryHandler = new GetAllClientsQueryHandler(clientRepositoryMock.Object);

			// Act
			var clientViewModelList = await getAllClientQueryHandler.Handle(getAllClientQuery, new CancellationToken());

			// Assert
			Assert.NotNull(clientViewModelList);
			Assert.NotEmpty(clientViewModelList);
			Assert.Equal(clients.Count, clientViewModelList.Count);

			clientRepositoryMock.Verify(c => c.GetAllAsync().Result, Times.Once);

		}
	}
}
