using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FCMABudgetAccounts.ViewModel;
using FCMABudgetAccounts.Database;

namespace FCMABudgetAccounts.Repository;

public static class UserRepository
{
    /// <summary>
    /// Get users
    /// </summary>
    /// <param name="context"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static List<UserEntity> GetUsers(
        IConnectionStringsRepository connectionStringsRepository)
    {
        // get connection string for database
        string connectionString = connectionStringsRepository.budgetsDbConnection;

        // set up database options
        var options = new DbContextOptionsBuilder<FcmaBudgetsDbContext>()
                   .UseSqlServer(connectionString)
                   .Options;

        // set up database context
        FcmaBudgetsDbContext context = new FcmaBudgetsDbContext(options);

        // set up result list
        List<UserEntity> accounts = new List<UserEntity>();

        // query users
        var usersResult = context.Users
            .FromSql($"EXECUTE dbo.sp_GetUsers")
            .ToList();

        // set up result from returned data
        foreach (User user in usersResult)
        {
            accounts.Add(Convert(user));
        }

        // return result
        return accounts;
    }

    /// <summary>
    /// Convert from database account to view model account entity
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public static UserEntity Convert(User user)
    {
        return new UserEntity()
        {
            UserId = user.UserId,
            UserName = user.UserName,
            CreateDate = user.CreateDate,
            ModifiedDate = user.ModifiedDate
        };
    }
}
