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
    private readonly IConnectionStringsRepository _connectionStringsRepository;

    public UserController(
        ILogger<AccountController> logger,
        IConnectionStringsRepository connectionStringsRepository)
    {
        _logger = logger;
        _connectionStringsRepository = connectionStringsRepository;
    }

    [HttpGet(Name = "GetUsers")]
    public JsonResult Get()
    {
        // get users
        IEnumerable<UserEntity> users = UserRepository.GetUsers(
            _connectionStringsRepository);

        // return users
        return Json(users);
    }
}
