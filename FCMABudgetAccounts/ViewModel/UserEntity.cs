using System.Collections.Generic;


namespace FCMABudgetAccounts.ViewModel;

public class UserEntity
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
