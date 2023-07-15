using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class ShareTransfer
{
    public Guid TransferId { get; set; }

    public int? SenderAccountNumber { get; set; }

    public int? ReceiverAccountNumber { get; set; }

    public int? ShareCount { get; set; }

    public DateTime? TimeStamp { get; set; }

    public virtual Account? ReceiverAccountNumberNavigation { get; set; }

    public virtual Account? SenderAccountNumberNavigation { get; set; }
}
