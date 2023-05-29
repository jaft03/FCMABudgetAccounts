using Microsoft.AspNetCore.Mvc;
using FCMABudgetAccounts.ViewModel;
using FCMABudgetAccounts.Database;
using FCMABudgetAccounts.Repository;

namespace FCMABudgetAccounts.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly FcmaBudgetsDbContext _context;

    public AccountController(
        ILogger<AccountController> logger,
        FcmaBudgetsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetAccounts")]
    public IEnumerable<AccountEntity> Get(Guid userId)
    {
        // get accounts for user
        IEnumerable<AccountEntity> accounts = AccountRepository.GetAccounts(_context, userId);

        // return accounts
        return accounts;
    }
}
