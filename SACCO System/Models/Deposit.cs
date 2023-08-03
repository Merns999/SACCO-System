using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACCO_System.Models;

public partial class Deposit
{
    public string DepositId { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public string DepositTypeId { get; set; } 

    public DateTime? Timestamp { get; set; }

    public string? TransactionReferenceNumber { get; set; }

    public string? TransactionStatus { get; set; }

    public virtual Account? AccountNumberNavigation { get; set; }

    [ForeignKey("DepositTypeId")]
    public virtual Deposittype DepositType { get; set; }
}
