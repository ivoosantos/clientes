using Clientes.Application.Commands.CreateClient;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Validators
{
	public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
	{
		public CreateClientCommandValidator()
		{
			RuleFor(p => p.Name)
				.MinimumLength(3)
				.WithMessage("Tamanho mínimo do nome é de 3 caracteres.");
			RuleFor(p => p.LastName)
				.MinimumLength(3)
				.WithMessage("Tamanho mínimo do sobrenome é de 3 caracteres.");
			RuleFor(c => c.Cpf)
				.Length(11)
				.WithMessage("O Cpf deve conter 11 caracteres numericos.");

		}
	}
}
