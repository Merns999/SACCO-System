using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.SharesRepository
{
    public interface ISharesRepository
    {
        Task<Shareholder> GetSharesByMemberId(Member member);
        Task<Response> SharesTransferRequest(int sender_Account_number, int receiver_Account_Number, int shares);
        Task<Response> ConfirmSharesTransfer(ShareTransfer shareTransfer);
    }
}
