using Microsoft.AspNetCore.Mvc;
using FCMABudgetAccounts.ViewModel;
using FCMABudgetAccounts.Database;
using FCMABudgetAccounts.Repository;
using Microsoft.EntityFrameworkCore.Query;

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
        // for debugging
        System.Diagnostics.Debug.WriteLine("GetUsers");

        // get users
        IEnumerable<UserEntity> users = UserRepository.GetUsers(
            _connectionStringsRepository);

        // return users
        return Json(users);
    }
}
