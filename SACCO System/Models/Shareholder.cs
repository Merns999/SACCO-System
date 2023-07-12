using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Shareholder
{
    public int ShareholderId { get; set; }

    public int? MemberId { get; set; }

    public int? ShareCount { get; set; }

    public virtual Member? Member { get; set; }
}
