using System;
using System.Collections.Generic;

namespace FCMABudgetAccounts.ViewModel;

public class AccountEntity
{
    public Guid AccountId { get; set; }

    public Guid UserId { get; set; }

    public string AccountName { get; set; } = null!;

    public double Balance { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
