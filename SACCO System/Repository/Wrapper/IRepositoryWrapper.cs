using SACCO_System.Repository.Accounts;
using SACCO_System.Repository.Admins;
using SACCO_System.Repository.Deposits;
using SACCO_System.Repository.Dividends;
using SACCO_System.Repository.Loans;
using SACCO_System.Repository.Members;
using SACCO_System.Repository.Shares;
using SACCO_System.Repository.Withdrawals;

namespace SACCO_System.Repository.Wrapper
{
    public interface IRepositoryWrapper
    {
        IAdminRepository AdminRepository { get;  }
        IDividendRepository DividendRepository { get; }
        ISharesRepository SharesRepository { get;  }
        IDepositRepository DepositRepository { get;  }
        IWithdrawalRepository WithdrawalRepository { get;  }
        IAccountRepository AccountRepository { get;  }
        IMemberRepository MemberRepository { get; }
        ILoanRepository LoanRepository { get; }
        void Save();

    }
}
