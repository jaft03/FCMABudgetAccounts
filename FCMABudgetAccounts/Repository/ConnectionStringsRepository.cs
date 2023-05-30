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
            return configuration.GetValue<string>("ConnectionStrings:FCMA_BudgetsDB")!;
        }
    }

}
