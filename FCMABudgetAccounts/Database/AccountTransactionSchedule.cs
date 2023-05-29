using System;
using System.Collections.Generic;

namespace FCMABudgetAccounts.Database;

public partial class AccountTransactionSchedule
{
    public Guid ScheduleId { get; set; }

    public Guid AccountId { get; set; }

    public string ScheduleName { get; set; } = null!;

    public double Amount { get; set; }

    public DateTime StartDate { get; set; }

    public int RepeatDayInterval { get; set; }

    public int RepeatWeekInterval { get; set; }

    public int RepeatDayOfWeek { get; set; }

    public int RepeatMonthInterval { get; set; }

    public int RepeatDayOfMonth { get; set; }

    public int RepeatYearInterval { get; set; }

    public int RepeatMonthOfYear { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Account Account { get; set; } = null!;
}
