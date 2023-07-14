using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Deposits
{
    public interface IDepositRepository
    {
        Task<Deposit> MakeDepositRequest(Deposit deposit);
        Task<TransactionStatus> GetDepositTransactionStatus(Deposit deposit);
    }
}
