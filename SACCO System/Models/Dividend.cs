using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Dividend : IEntity
{
    public string? DividendId { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? DividendStatus { get; set; }

    public string? DividendCalculationMethod { get; set; }

    public virtual Account? AccountNumberNavigation { get; set; }

    public virtual ICollection<DividendPayment> DividendPayments { get; set; } = new List<DividendPayment>();
}
