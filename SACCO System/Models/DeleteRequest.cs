using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class DeleteRequest
{
    public int DeleteRequestId { get; set; }

    public int? AccountNumber { get; set; }

    public DateTime? TimeStamp { get; set; }

    public virtual Account? AccountNumberNavigation { get; set; }
}
