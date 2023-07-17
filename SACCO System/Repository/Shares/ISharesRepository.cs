using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.SharesRepository
{
    public interface ISharesRepository
    {
        Task<decimal?> GetSharesByMemberId(Member member);
        Task<Response> SharesTransferRequest(Member sender_Member, Member receiver_Member, int shares);
        //Task<Response> ConfirmSharesTransfer(ShareTransfer shareTransfer);
    }
}
