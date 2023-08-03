using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class DeleteRequest
{
    //public DeleteRequest(string guid, int accountNumber, DateTime utcNow, Account deleteRequestAccount)
    //{
    //    DeleteRequestId = guid;
    //    AccountNumber = accountNumber;
    //    TimeStamp= utcNow;
    //    AccountNumberNavigation = deleteRequestAccount;
    //}

    public string DeleteRequestId { get; set; }

    public int? AccountNumber { get; set; }

    public DateTime? TimeStamp { get; set; }

    public virtual Account? AccountNumberNavigation { get; set; }
}
