using Microsoft.AspNetCore.Mvc;
using FCMABudgetAccounts.ViewModel;
using FCMABudgetAccounts.Database;
using FCMABudgetAccounts.Repository;

namespace FCMABudgetAccounts.Controllers;

[ApiController]
[Route("users")]
public class UserController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly FcmaBudgetsDbContext _context;

    public UserController(
        ILogger<AccountController> logger,
        FcmaBudgetsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<UserEntity> Get()
    {
        // get users
        IEnumerable<UserEntity> users = UserRepository.GetUsers(_context);

        // return users
        return users;
    }
}
