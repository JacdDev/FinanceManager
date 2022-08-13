using FinanceManager.Application;
using FinanceManager.Infrastructure;
using FinanceManager.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

var app = builder.Build();

app.MapControllers();

app.Run();
