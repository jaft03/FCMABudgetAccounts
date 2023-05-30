using Microsoft.AspNetCore.Mvc;
using FCMABudgetAccounts.ViewModel;
using FCMABudgetAccounts.Database;
using FCMABudgetAccounts.Repository;

namespace FCMABudgetAccounts.Controllers;

[ApiController]
[Route("transactions")]
public class AccountTransactionController : Controller
{
    private readonly ILogger<AccountTransactionController> _logger;
    private readonly IConnectionStringsRepository _connectionStringsRepository;

    public AccountTransactionController(
        ILogger<AccountTransactionController> logger,
        IConnectionStringsRepository connectionStringsRepository)
    {
        _logger = logger;
        _connectionStringsRepository = connectionStringsRepository;
    }

    [HttpGet(Name = "GetTransactions")]
    public IEnumerable<AccountTransactionEntity> Get(Guid accountId)
    {
        // get transactions for account
        IEnumerable<AccountTransactionEntity> transactions = AccountTransactionRepository.GetTransactions(
            _connectionStringsRepository, 
            accountId);

        // return transactions
        return transactions;
    }
}
