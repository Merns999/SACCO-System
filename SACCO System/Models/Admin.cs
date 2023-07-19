using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Admin: IEntity
{
    public int AdminId { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
