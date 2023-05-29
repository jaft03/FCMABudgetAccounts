using System;
using System.Collections.Generic;

namespace FCMABudgetAccounts.Database;

public partial class AccountTransaction
{
    public Guid TransactionId { get; set; }

    public Guid AccountId { get; set; }

    public string TransactionName { get; set; } = null!;

    public double Amount { get; set; }

    public DateTime TransactionDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Account Account { get; set; } = null!;
}
