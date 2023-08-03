using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACCO_System.Models;

public partial class ShareTransfer
{
    public string? TransferId { get; set; }

    public int SenderMemberID { get; set; }

    public int ReceiverMemberID { get; set; }

    public decimal? ShareCount { get; set; }

    public DateTime? TimeStamp { get; set; }

    [ForeignKey("ReceiverMemberID")]
    public virtual Member ReceiverMemberIDNavigation { get; set; }

    [ForeignKey("SenderMemberID")]
    public virtual Member SenderMemberIDNavigation { get; set; }
}
