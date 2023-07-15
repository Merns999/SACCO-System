using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Deposittype
{
    public Guid DepositTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
}
