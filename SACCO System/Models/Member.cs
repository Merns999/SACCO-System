using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public sbyte? DeleteRequest { get; set; }

    public string? MembershipStatus { get; set; }

    public string? Address { get; set; }

    public string? Occupation { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Guarantor> Guarantors { get; set; } = new List<Guarantor>();

    public virtual ICollection<LoanApplication> LoanApplications { get; set; } = new List<LoanApplication>();

    public virtual ICollection<Shareholder> Shareholders { get; set; } = new List<Shareholder>();

    public ICollection<ShareTransfer>? ShareTransferReceiverMemberIDNavigations { get; set; }
    public ICollection<ShareTransfer>? ShareTransferSenderMemberIDNavigations { get; set; }
}
