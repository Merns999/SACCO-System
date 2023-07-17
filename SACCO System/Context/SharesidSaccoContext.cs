using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SACCO_System.Models;

namespace SACCO_System.Data;

public partial class SharesidSaccoContext : DbContext
{
    public SharesidSaccoContext()
    {
    }

    public SharesidSaccoContext(DbContextOptions<SharesidSaccoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<DeleteRequest> DeleteRequests { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Deposittype> Deposittypes { get; set; }

    public virtual DbSet<Dividend> Dividends { get; set; }

    public virtual DbSet<DividendPayment> DividendPayments { get; set; }

    public virtual DbSet<Guarantor> Guarantors { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanApplication> LoanApplications { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<ShareTransfer> ShareTransfers { get; set; }

    public virtual DbSet<Shareholder> Shareholders { get; set; }

    public virtual DbSet<Withdrawal> Withdrawals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=DefaultConnection", ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PRIMARY");

            entity.ToTable("account");

            entity.HasIndex(e => e.MemberId, "Member_ID");

            entity.Property(e => e.AccountNumber)
                .ValueGeneratedNever()
                .HasColumnName("Account_Number");
            entity.Property(e => e.AccountBalance)
                .HasPrecision(18, 2)
                .HasColumnName("Account_Balance");
            entity.Property(e => e.AccountName)
                .HasMaxLength(255)
                .HasColumnName("Account_Name");
            entity.Property(e => e.AccountType)
                .HasMaxLength(255)
                .HasColumnName("Account_Type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.LastTransactionTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Last_TransactionTimestamp");
            entity.Property(e => e.LockStatus).HasColumnName("Lock_Status");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");

            entity.HasOne(d => d.Member).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("account_ibfk_1");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("Admin_ID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_Number");
        });

        modelBuilder.Entity<DeleteRequest>(entity =>
        {
            entity.HasKey(e => e.DeleteRequestId).HasName("PRIMARY");

            entity.ToTable("delete_request");

            entity.HasIndex(e => e.AccountNumber, "Account_Number");

            entity.Property(e => e.DeleteRequestId)
                .ValueGeneratedNever()
                .HasColumnName("Delete_Request_ID");
            entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.DeleteRequests)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("delete_request_ibfk_1");
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(e => e.DepositId).HasName("PRIMARY");

            entity.ToTable("deposit");

            entity.HasIndex(e => e.AccountNumber, "Account_Number");

            entity.HasIndex(e => e.DepositTypeId, "Deposit_Type_ID");

            entity.Property(e => e.DepositId)
                .ValueGeneratedNever()
                .HasColumnName("Deposit_ID");
            entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.DepositTypeId).HasColumnName("Deposit_Type_ID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.TransactionReferenceNumber)
                .HasMaxLength(255)
                .HasColumnName("Transaction_Reference_Number");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(20)
                .HasColumnName("Transaction_Status");

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("deposit_ibfk_1");

            entity.HasOne(d => d.DepositType).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.DepositTypeId)
                .HasConstraintName("deposit_ibfk_2");
        });

        modelBuilder.Entity<Deposittype>(entity =>
        {
            entity.HasKey(e => e.DepositTypeId).HasName("PRIMARY");

            entity.ToTable("deposittype");

            entity.Property(e => e.DepositTypeId)
                .ValueGeneratedNever()
                .HasColumnName("Deposit_Type_ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Dividend>(entity =>
        {
            entity.HasKey(e => e.DividendId).HasName("PRIMARY");

            entity.ToTable("dividend");

            entity.HasIndex(e => e.AccountNumber, "Account_Number");

            entity.Property(e => e.DividendId)
                .ValueGeneratedNever()
                .HasColumnName("Dividend_ID");
            entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.DividendCalculationMethod)
                .HasMaxLength(255)
                .HasColumnName("Dividend_Calculation_Method");
            entity.Property(e => e.DividendStatus)
                .HasMaxLength(20)
                .HasColumnName("Dividend_Status");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.Dividends)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("dividend_ibfk_1");
        });

        modelBuilder.Entity<DividendPayment>(entity =>
        {
            entity.HasKey(e => e.DividendPaymentId).HasName("PRIMARY");

            entity.ToTable("dividend_payment");

            entity.HasIndex(e => e.AccountNumber, "Account_Number");

            entity.HasIndex(e => e.DividendId, "Dividend_ID");

            entity.Property(e => e.DividendPaymentId)
                .ValueGeneratedNever()
                .HasColumnName("Dividend_Payment_ID");
            entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.DividendId).HasColumnName("Dividend_ID");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.DividendPayments)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("dividend_payment_ibfk_2");

            entity.HasOne(d => d.Dividend).WithMany(p => p.DividendPayments)
                .HasForeignKey(d => d.DividendId)
                .HasConstraintName("dividend_payment_ibfk_1");
        });

        modelBuilder.Entity<Guarantor>(entity =>
        {
            entity.HasKey(e => e.GuarantorId).HasName("PRIMARY");

            entity.ToTable("guarantor");

            entity.HasIndex(e => e.LoanId, "Loan_ID");

            entity.HasIndex(e => e.MemberId, "Member_ID");

            entity.Property(e => e.GuarantorId)
                .ValueGeneratedNever()
                .HasColumnName("Guarantor_ID");
            entity.Property(e => e.LoanId).HasColumnName("Loan_ID");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");

            entity.HasOne(d => d.Loan).WithMany(p => p.Guarantors)
                .HasForeignKey(d => d.LoanId)
                .HasConstraintName("guarantor_ibfk_2");

            entity.HasOne(d => d.Member).WithMany(p => p.Guarantors)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("guarantor_ibfk_1");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PRIMARY");

            entity.ToTable("loan");

            entity.HasIndex(e => e.GuarantorId, "Guarantor_ID");

            entity.HasIndex(e => e.LoanApplicationId, "Loan_Application_ID");

            entity.Property(e => e.LoanId)
                .ValueGeneratedNever()
                .HasColumnName("Loan_ID");
            entity.Property(e => e.AnnualIncome).HasColumnName("Annual_Income");
            entity.Property(e => e.CompoundInterest)
                .HasPrecision(18, 2)
                .HasColumnName("Compound_Interest");
            entity.Property(e => e.GuarantorId).HasColumnName("Guarantor_ID");
            entity.Property(e => e.LastPaymentTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Last_Payment_Timestamp");
            entity.Property(e => e.LoanApplicationId).HasColumnName("Loan_Application_ID");
            entity.Property(e => e.LoanPeriod).HasColumnName("Loan_Period");
            entity.Property(e => e.LoanPrinciple).HasColumnName("Loan_Principle");
            entity.Property(e => e.LoanStatus).HasColumnName("Loan_Status");
            entity.Property(e => e.RepaymentSchedule)
                .HasMaxLength(255)
                .HasColumnName("Repayment_Schedule");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
            entity.Property(e => e.TypeOfLoan)
                .HasMaxLength(255)
                .HasColumnName("Type_Of_Loan");

            entity.HasOne(d => d.Guarantor).WithMany(p => p.Loans)
                .HasForeignKey(d => d.GuarantorId)
                .HasConstraintName("loan_ibfk_2");

            entity.HasOne(d => d.LoanApplication).WithMany(p => p.Loans)
                .HasForeignKey(d => d.LoanApplicationId)
                .HasConstraintName("loan_ibfk_1");
        });

        modelBuilder.Entity<LoanApplication>(entity =>
        {
            entity.HasKey(e => e.LoanApplicationId).HasName("PRIMARY");

            entity.ToTable("loan_application");

            entity.HasIndex(e => e.MemberId, "Member_ID");

            entity.Property(e => e.LoanApplicationId)
                .ValueGeneratedNever()
                .HasColumnName("Loan_Application_ID");
            entity.Property(e => e.AnnualIncome).HasColumnName("Annual_Income");
            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(20)
                .HasColumnName("Application_Status");
            entity.Property(e => e.Guarantor).HasMaxLength(255);
            entity.Property(e => e.LoanPeriod).HasColumnName("Loan_Period");
            entity.Property(e => e.LoanPrinciple).HasColumnName("Loan_Principle");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.ReasonForRejection)
                .HasMaxLength(255)
                .HasColumnName("Reason_For_Rejection");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
            entity.Property(e => e.TypeOfLoan)
                .HasMaxLength(255)
                .HasColumnName("Type_Of_Loan");

            entity.HasOne(d => d.Member).WithMany(p => p.LoanApplications)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("loan_application_ibfk_1");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("member");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("Member_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_Of_Birth");
            entity.Property(e => e.DeleteRequest).HasColumnName("Delete_Request");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.MembershipStatus)
                .HasMaxLength(20)
                .HasColumnName("Membership_Status");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Occupation).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_number");
        });

        modelBuilder.Entity<ShareTransfer>(entity =>
        {
            entity.HasKey(e => e.TransferId).HasName("PRIMARY");

            entity.ToTable("share_transfer");

            entity.HasIndex(e => e.ReceiverMemberID, "Receiver_Member_ID");

            entity.HasIndex(e => e.SenderMemberID, "Sender_Member_ID");

            entity.Property(e => e.TransferId)
                .ValueGeneratedNever()
                .HasColumnName("Transfer_ID");
            entity.Property(e => e.ReceiverMemberID).HasColumnName("Receiver_Member_ID");
            entity.Property(e => e.SenderMemberID).HasColumnName("Sender_Member_ID");
            entity.Property(e => e.ShareCount).HasColumnName("Share_Count");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");

            entity.HasOne(d => d.ReceiverMemberIDNavigation).WithMany(p => p.ShareTransferReceiverMemberIDNavigations)
                .HasForeignKey(d => d.ReceiverAccountNumber)
                .HasConstraintName("share_transfer_ibfk_2");

            entity.HasOne(d => d.SenderMemberIDNavigation).WithMany(p => p.ShareTransferSenderMemberIDNavigations)
                .HasForeignKey(d => d.SenderAccountNumber)
                .HasConstraintName("share_transfer_ibfk_1");
        });

        modelBuilder.Entity<Shareholder>(entity =>
        {
            entity.HasKey(e => e.ShareholderId).HasName("PRIMARY");

            entity.ToTable("shareholder");

            entity.HasIndex(e => e.MemberId, "Member_ID");

            entity.Property(e => e.ShareholderId)
                .ValueGeneratedNever()
                .HasColumnName("Shareholder_ID");
            entity.Property(e => e.MemberId).HasColumnName("Member_ID");
            entity.Property(e => e.ShareCount).HasColumnName("Share_Count");

            entity.HasOne(d => d.Member).WithMany(p => p.Shareholders)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("shareholder_ibfk_1");
        });

        modelBuilder.Entity<Withdrawal>(entity =>
        {
            entity.HasKey(e => e.WithdrawalId).HasName("PRIMARY");

            entity.ToTable("withdrawal");

            entity.HasIndex(e => e.AccountNumber, "Account_Number");

            entity.Property(e => e.WithdrawalId)
                .ValueGeneratedNever()
                .HasColumnName("Withdrawal_ID");
            entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
            entity.Property(e => e.TransactionReferenceNumber)
                .HasMaxLength(255)
                .HasColumnName("Transaction_Reference_Number");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(20)
                .HasColumnName("Transaction_Status");

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.Withdrawals)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("withdrawal_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
