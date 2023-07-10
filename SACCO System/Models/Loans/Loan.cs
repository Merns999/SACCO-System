using SACCO_MANAGEMENT.Data.LoanInterfaces;
using SACCO_MANAGEMENT.Models.Deposits;
using SACCO_MANAGEMENT.Models.Users.Guarantors;

namespace SACCO_MANAGEMENT.Models.Loans
{
    public class Loan
    {
        Guid Id { get; set; }
        int IDNumber { get; set; }
        LoanType TypeOfLoan { get; set; }
        int AnnualIncome { get; set; }
        double LoanRepaymentPeriod { get; set; }
        int LoanPrinciple { get; set; }
        Guid GuarantorID { get; set; }
        LoanStatus LoanStatus { get; set; }

        public Guarantors? Guarantors { get; set; }
        public List<LoanInstallment>? LoanInstallments { get; set; }
    }
}