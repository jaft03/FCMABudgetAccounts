using System;
using System.Collections.Generic;

namespace FCMABudgetAccounts.Database;

public partial class Account
{
    public Guid AccountId { get; set; }

    public Guid UserId { get; set; }

    public string AccountName { get; set; } = null!;

    public double Balance { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<AccountTransactionSchedule> AccountTransactionSchedules { get; set; } = new List<AccountTransactionSchedule>();

    public virtual ICollection<AccountTransaction> AccountTransactions { get; set; } = new List<AccountTransaction>();

    public virtual User User { get; set; } = null!;
}
