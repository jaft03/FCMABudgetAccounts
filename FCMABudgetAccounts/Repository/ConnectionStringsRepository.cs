using Azure.Security.KeyVault.Secrets;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

namespace FCMABudgetAccounts.Repository;

public class ConnectionStringsRepository : IConnectionStringsRepository
{
    private IConfiguration configuration;

    public ConnectionStringsRepository(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string budgetsDbConnection 
    { 
        get
        {
            // get connection string
            string? connectionString = configuration.GetValue<string>("ConnectionStringsFCMABudgetsDB");

            // display trace if not set
            if(connectionString == null) 
            {
                System.Diagnostics.Trace.TraceError("ConnectionStringsFCMABudgetsDB connection string not set.");
                connectionString = "";
            }
            
            // return result
            return connectionString!;
        }
    }

}
