using SACCO_System.Data;
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
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SharesidSaccoContext _sharesidSaccoContext;

        private IAccountRepository _accountRepository;
        private IAdminRepository _adminRepository;
        private IDepositRepository _depositRepository;
        private IDividendRepository _dividendRepository;
        private ILoanRepository _loanRepository;
        private IMemberRepository _memberRepository;
        private ISharesRepository _sharesRepository;
        private IWithdrawalRepository _withdrawalRepository;

        public RepositoryWrapper(SharesidSaccoContext sharesidSaccoContext) => _sharesidSaccoContext = sharesidSaccoContext;

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_sharesidSaccoContext);
                }

                return _accountRepository;
            }
        }

        public IAdminRepository AdminRepository
        {
            get
            {
                if (_adminRepository == null)
                {
                    _adminRepository = new AdminRepository(_sharesidSaccoContext);
                }

                return _adminRepository;
            }
        }

        public IDividendRepository DividendRepository
        {
            get
            {
                if (_dividendRepository == null)
                {
                    _dividendRepository = new DividendRepository(_sharesidSaccoContext);
                }

                return _dividendRepository;
            }
        }

        public ISharesRepository SharesRepository
        {
            get
            {
                if (_sharesRepository == null)
                {
                    _sharesRepository = new SharesRepository(_sharesidSaccoContext);
                }

                return _sharesRepository;
            }
        }

        public IDepositRepository DepositRepository
        {
            get
            {
                if (_depositRepository == null)
                {
                    _depositRepository = new DepositRepository(_sharesidSaccoContext);
                }

                return _depositRepository;
            }
        }

        public IWithdrawalRepository WithdrawalRepository
        {
            get
            {
                if (_withdrawalRepository == null)
                {
                    _withdrawalRepository = new WithdrawalRepository(_sharesidSaccoContext);
                }

                return _withdrawalRepository;
            }
        }

        public IMemberRepository MemberRepository
        {
            get
            {
                if (_memberRepository == null)
                {
                    _memberRepository = new MemberRepository(_sharesidSaccoContext);
                }

                return _memberRepository;
            }
        }

        public ILoanRepository LoanRepository
        {
            get
            {
                if (_loanRepository == null)
                {
                    _loanRepository = new LoanRepository(_sharesidSaccoContext);
                }

                return _loanRepository;
            }
        }

        public void Save()
        {
            _sharesidSaccoContext.SaveChanges();
        }
    }
}
