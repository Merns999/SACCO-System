using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Deposits
{
    public interface IDepositRepository
    {
        Task<TransactionStatus> MakeDepositRequest(Deposit deposit);
        Task<string> GetDepositTransactionStatus(Deposit deposit);
    }
}
