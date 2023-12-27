using Clientes.Application.Commands.CreateClient;
using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.UnitTests.Application.Commands
{
	public class CreateClientCommandHandlerTests
	{
		[Fact]
		public async Task InputDataIsOk_Executed_ReturnClientId()
		{
			var clientRepository = new Mock<IClientRepository>();

			var createClientCommand = new CreateClientCommand
			{
				Name = "test",
				LastName = "test",
				DateOfBirth = new DateTime(2000, 01, 25),
				Cpf = "22545612321",
				Rg = "12345678",
				Address = "Rua Dois",
				NumberAddress = "52C"
			};

			var createClientCommandHandler = new CreateClientCommandHandler(clientRepository.Object);

			// Act
			var id = await createClientCommandHandler.Handle(createClientCommand, new CancellationToken());

			// Assert
			Assert.True(id >= 0);

			clientRepository.Verify(c => c.AddAsync(It.IsAny<Client>()), Times.Once);
		}
	}
}
