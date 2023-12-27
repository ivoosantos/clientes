using Clientes.Application.Commands.CreateClient;
using Clientes.Application.Validators;
using Clientes.Core.Repositories;
using Clientes.Infrastructure.Persistence;
using Clientes.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Client");
builder.Services.AddDbContext<ClientDbContext>(p => p.UseSqlServer(connectionString));

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateClientCommandValidator>()
	.AddFluentValidationAutoValidation()
	.AddFluentValidationClientsideAdapters();

builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateClientCommand)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
