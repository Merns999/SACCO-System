using SACCO_System.Enumerables;
using SACCO_System.Models;
using SACCO_System.Repository.RepositoryBase;

namespace SACCO_System.Repository.Shares
{
    //SharesRepository uses two class types (ShareTransfer, Shareholder) for the business functionality.
    //It cannot automatically inherit from the base Repository class.
    //The manifest for this Repository(ISharesRepository) is inheriting the Base Repository Interface(IRepositoryBase)
    public interface ISharesRepository : IRepositoryBase<Shareholder>, IRepositoryBase<ShareTransfer>
    {
        Task<decimal?> GetSharesByMemberId(Member member);
        Task<Response> SharesTransferRequest(Member sender_Member, Member receiver_Member, int shares);
        //Task<Response> ConfirmSharesTransfer(ShareTransfer shareTransfer);
    }
}
