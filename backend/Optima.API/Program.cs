using DotNetEnv;
using FluentValidation;
using Optima.API.Middleware;
using Optima.Application.Users.Validators;
using Optima.Infrastructure.Ioc;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

builder.Services.RegisterDependencies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.UseHttpsRedirection();
app.Run();