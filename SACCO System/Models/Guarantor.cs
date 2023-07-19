﻿using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Guarantor : IEntity
{
    public int GuarantorId { get; set; }

    public string? LoanId { get; set; }

    public int? MemberId { get; set; }

    public virtual Loan? Loan { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Member? Member { get; set; }
}
