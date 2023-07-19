using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Shareholder : IEntity
{
    public string? ShareholderId { get; set; }

    public int? MemberId { get; set; }

    public decimal? ShareCount { get; set; }

    public virtual Member? Member { get; set; }
}
