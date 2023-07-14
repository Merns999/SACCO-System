using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Accounts
{
    public interface IAccountRepository
    {
        Task<Account> GetMemberAccountDetails(Member member);
        Task<LockStatus> CheckLockStatus(Member member);
        Task<decimal?> GetBalance(Member member);
        Task<Response> MakeDeleteRequest(Member member);
    }
}
