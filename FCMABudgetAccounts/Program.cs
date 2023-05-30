using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FCMABudgetAccounts.Database;

// set up web application builder
var builder = WebApplication.CreateBuilder(args);

// configure key vault
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
        new DefaultAzureCredential());
}

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure swagger
builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "FCMA Budget Accounts",
        Version = "v1"
    });
});

// set up database access
builder.Services.AddDbContext<FcmaBudgetsDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:FCMA_BudgetsDB"));

// set up app
var app = builder.Build();

// Needed to be always generated for cloud Azure deployment
app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
