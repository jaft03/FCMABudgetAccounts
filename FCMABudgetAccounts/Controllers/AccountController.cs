using Microsoft.AspNetCore.Mvc;
using FCMABudgetAccounts.ViewModel;
using FCMABudgetAccounts.Database;
using FCMABudgetAccounts.Repository;

namespace FCMABudgetAccounts.Controllers;

[ApiController]
[Route("accounts")]
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IConnectionStringsRepository _connectionStringsRepository;

    public AccountController(
        ILogger<AccountController> logger,
        IConnectionStringsRepository connectionStringsRepository)
    {
        _logger = logger;
        _connectionStringsRepository = connectionStringsRepository;
    }

    [HttpGet(Name = "GetAccounts")]
    public IEnumerable<AccountEntity> Get(Guid userId)
    {
        // get accounts for user
        IEnumerable<AccountEntity> accounts = AccountRepository.GetAccounts(
            _connectionStringsRepository, 
            userId);

        // return accounts
        return accounts;
    }
}
