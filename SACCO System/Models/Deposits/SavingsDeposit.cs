namespace SACCO_MANAGEMENT.Models.Deposits
{
    public class SavingsDeposit
    {
        Guid Id { get; set; }
        int DepositID { get; set; }
        int AccountID { get; set; }
        int Amount { get; set; }
        DateTime Date { get; set; }
    }
}
