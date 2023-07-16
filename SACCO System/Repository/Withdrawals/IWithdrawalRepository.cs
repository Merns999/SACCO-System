using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Withdrawals
{
    public interface IWithdrawalRepository
    {
        Task<Response> MakeWithdrawalRequest(Withdrawal request);
        Task<string?> CheckWithdrawalTransactionStatus(Member member);
    }
}
