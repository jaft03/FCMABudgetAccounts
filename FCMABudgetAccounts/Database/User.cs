using System;
using System.Collections.Generic;

namespace FCMABudgetAccounts.Database;

public partial class User
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
