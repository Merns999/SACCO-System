namespace SACCO_MANAGEMENT.Models.Deposits
{
    public class Deposit
    {
        Guid DepositID { get; set; }
        int IDNumber { get; set; }
        int Amount { get; set; }
        DateTime DateDeposited { get; set; }
        int DepositTypeId { get; set; }
    }
}
