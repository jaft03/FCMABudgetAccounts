using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FCMABudgetAccounts.Database;
using Microsoft.Extensions.Configuration;
using FCMABudgetAccounts.Repository;

// set up web application builder
var builder = WebApplication.CreateBuilder(args);

// configure key vault
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
        new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            ExcludeEnvironmentCredential = true,
            ExcludeInteractiveBrowserCredential = true,
            ExcludeAzurePowerShellCredential = true,
            ExcludeSharedTokenCacheCredential = true,
            ExcludeVisualStudioCodeCredential = true,
            ExcludeVisualStudioCredential = true,
            // The following two I'm explicitly setting to false but they could be omitted because false is the default
            ExcludeAzureCliCredential = false,
            ExcludeManagedIdentityCredential = false,
        }));
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

// add dependency injection for connection strings
builder.Services.AddSingleton<IConnectionStringsRepository, ConnectionStringsRepository>();

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
