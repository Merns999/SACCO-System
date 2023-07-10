namespace SACCO_MANAGEMENT.Models.Deposits
{
    public class InitialMemberDeposit
    {
        Guid Id { get; set; }
        int DepositId { get; set; }
        int IDNumber { get; set; }
        int Amount { get; set; }
        DateTime Date { get; set; }
    }
}
