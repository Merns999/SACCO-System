namespace SACCO_MANAGEMENT.Models.Deposits
{
    public class LoanInstallment
    {
        Guid Id { get; set; }
        int DepositId { get; set; }
        int LoanId { get; set; }
        int Amount { get; set; }
        DateTime Date { get; set; }
    }
}
