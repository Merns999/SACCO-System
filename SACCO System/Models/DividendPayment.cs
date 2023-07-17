using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class DividendPayment
{
    public string? DividendPaymentId { get; set; }

    public string? DividendId { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? TimeStamp { get; set; }

    public virtual Account? AccountNumberNavigation { get; set; }

    public virtual Dividend? Dividend { get; set; }
}
