namespace SACCO_MANAGEMENT.Models.Account
{
    public class Account
    {
        int AccountNumber { get; set; }
        int IDNumber { get; set; }
        string? AccountName { get; set; }
        //LockStatus{get; set;}
        DateTime? CreatedAt { get; set; }
    }
}
