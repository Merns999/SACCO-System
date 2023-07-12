using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Deposit
{
    public int DepositId { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public int? DepositTypeId { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? TransactionReferenceNumber { get; set; }

    public string? TransactionStatus { get; set; }

    public virtual Account? AccountNumberNavigation { get; set; }

    public virtual Deposittype? DepositType { get; set; }
}
