using System;
using System.Collections.Generic;

namespace SACCO_System.Models;

public partial class Account : IEntity
{
    public int AccountNumber { get; set; }

    public int? MemberId { get; set; }

    public string? AccountName { get; set; }

    public sbyte? LockStatus { get; set; }

    public string? AccountType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public decimal? AccountBalance { get; set; }

    public DateTime? LastTransactionTimestamp { get; set; }

    public virtual ICollection<DeleteRequest> DeleteRequests { get; set; } = new List<DeleteRequest>();

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();

    public virtual ICollection<DividendPayment> DividendPayments { get; set; } = new List<DividendPayment>();

    public virtual ICollection<Dividend> Dividends { get; set; } = new List<Dividend>();

    public virtual Member? Member { get; set; }

    public virtual ICollection<ShareTransfer> ShareTransferReceiverAccountNumberNavigations { get; set; } = new List<ShareTransfer>();

    public virtual ICollection<ShareTransfer> ShareTransferSenderAccountNumberNavigations { get; set; } = new List<ShareTransfer>();

    public virtual ICollection<Withdrawal> Withdrawals { get; set; } = new List<Withdrawal>();
}
