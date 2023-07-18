using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class LoanApplication
{
    public string? LoanApplicationId { get; set; }

    public int? MemberId { get; set; }

    public string? Guarantor { get; set; }

    public string? TypeOfLoan { get; set; }

    public int? AnnualIncome { get; set; }

    public int? LoanPeriod { get; set; }

    public int? LoanPrinciple { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? ApplicationStatus { get; set; }

    public string? ReasonForRejection { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Member? Member { get; set; }
}
