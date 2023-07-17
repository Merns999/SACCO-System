using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Loan
{
    public string? LoanId { get; set; }

    public string? LoanApplicationId { get; set; }

    public string? TypeOfLoan { get; set; }

    public int? AnnualIncome { get; set; }

    public int? LoanPeriod { get; set; }

    public int? LoanPrinciple { get; set; }

    public decimal? CompoundInterest { get; set; }

    public int? GuarantorId { get; set; }

    public sbyte? LoanStatus { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? RepaymentSchedule { get; set; }

    public DateTime? LastPaymentTimestamp { get; set; }

    public virtual Guarantor? Guarantor { get; set; }

    public virtual ICollection<Guarantor> Guarantors { get; set; } = new List<Guarantor>();

    public virtual LoanApplication? LoanApplication { get; set; }
}
