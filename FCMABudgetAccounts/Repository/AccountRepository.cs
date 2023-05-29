using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FCMABudgetAccounts.ViewModel;
using FCMABudgetAccounts.Database;

namespace FCMABudgetAccounts.Repository;

public static class AccountRepository
{
    /// <summary>
    /// Get accounts by user id
    /// </summary>
    /// <param name="context"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static List<AccountEntity> GetAccounts(
        FcmaBudgetsDbContext context,
        Guid userId)
    {
        // set up result list
        List<AccountEntity> accounts = new List<AccountEntity>();

        // query accounts
        var accountsResult = context.Accounts
            .FromSql($"EXECUTE dbo.sp_GetAccounts @UserID={userId}")
            .ToList();

        // set up result from returned data
        foreach (Account account in accountsResult)
        {
            accounts.Add(Convert(account));
        }

        // return result
        return accounts;
    }

    /// <summary>
    /// Convert from database account to view model account entity
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public static AccountEntity Convert(Account account)
    {
        return new AccountEntity()
        {
            AccountId = account.AccountId,
            UserId = account.UserId,
            AccountName = account.AccountName,
            Balance = account.Balance,
            StartDate = account.StartDate,
            CreateDate = account.CreateDate,
            ModifiedDate = account.ModifiedDate
        };
    }
}
