using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Withdrawals
{
    public interface IWithdrawalRepository
    {
        Task<Withdrawal> MakeWithdrawalRequest(Withdrawal request);
        Task<TransactionStatus> CheckWithdrawalTransactionStatus(Withdrawal request);
    }
}
