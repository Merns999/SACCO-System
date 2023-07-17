using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Withdrawal
{
    public string? WithdrawalId { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? TransactionReferenceNumber { get; set; }

    public string? TransactionStatus { get; set; }

    public virtual Account? AccountNumberNavigation { get; set; }
}
