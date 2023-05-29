using System;
using System.Collections.Generic;

namespace FCMABudgetAccounts.ViewModel;

public class AccountTransactionEntity
{
    public Guid TransactionId { get; set; }

    public Guid AccountId { get; set; }

    public string TransactionName { get; set; } = null!;

    public double Amount { get; set; }

    public DateTime TransactionDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
