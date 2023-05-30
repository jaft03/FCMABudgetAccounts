using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FCMABudgetAccounts.ViewModel;
using FCMABudgetAccounts.Database;

namespace FCMABudgetAccounts.Repository;


public static class AccountTransactionRepository 
{
    /// <summary>
    /// Get transactions by account id
    /// </summary>
    /// <param name="context"></param>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public static List<AccountTransactionEntity> GetTransactions(
        IConnectionStringsRepository connectionStringsRepository,
        Guid accountId)
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
        List<AccountTransactionEntity> accounts = new List<AccountTransactionEntity>();

        // query transactions
        var transactionsResult = context.AccountTransactions
            .FromSql($"EXECUTE dbo.sp_GetTransactions @AccountID={accountId}")
            .ToList();

        // set up result from returned data
        foreach (AccountTransaction account in transactionsResult)
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
    public static AccountTransactionEntity Convert(AccountTransaction transaction)
    {
        return new AccountTransactionEntity()
        {
            TransactionId = transaction.TransactionId,
            AccountId = transaction.AccountId,
            TransactionName = transaction.TransactionName,
            Amount = transaction.Amount,
            TransactionDate = transaction.TransactionDate,
            CreateDate = transaction.CreateDate,
            ModifiedDate = transaction.ModifiedDate
        };
    }
}
