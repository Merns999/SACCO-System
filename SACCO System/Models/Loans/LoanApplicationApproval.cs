namespace SACCO_MANAGEMENT.Models.Loans
{
    public class LoanApplicationApproval
    {
        Guid ID { get; set; }
        int IDNumber { get; set; }
        string Guarantor { get; set; }
        string TypeOfLoan { get; set; }
        int AnnualIncome { get; set; }
        int LoanPeriod { get; set; }
        int LoanPrinciple { get; set; }
    }
}
