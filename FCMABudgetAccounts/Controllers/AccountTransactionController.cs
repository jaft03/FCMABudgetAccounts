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
    private readonly FcmaBudgetsDbContext _context;

    public AccountTransactionController(
        ILogger<AccountTransactionController> logger,
        FcmaBudgetsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetTransactions")]
    public IEnumerable<AccountTransactionEntity> Get(Guid accountId)
    {
        // get transactions for account
        IEnumerable<AccountTransactionEntity> transactions = AccountTransactionRepository.GetTransactions(_context, accountId);

        // return transactions
        return transactions;
    }
}
