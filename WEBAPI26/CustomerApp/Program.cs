using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Api.Services; // for ICustomerService, CustomerService

var builder = WebApplication.CreateBuilder(args);

// Register CustomerService in DI
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

// (Optional but common)
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();