using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;
using SACCO_System.Repository.SharesRepository;

namespace SACCO_System.Repository.Shares
{
    public class SharesRepository : ISharesRepository
    {
        private readonly SharesidSaccoContext _sharesidSaccoContext;

        public SharesRepository(SharesidSaccoContext sharesidSaccoContext) => _sharesidSaccoContext = sharesidSaccoContext;

        public async Task<Response> ConfirmSharesTransfer(ShareTransfer shareTransfer)
        {
            //The shares transfer table needs some modifications;
    
            await _sharesidSaccoContext.ShareTransfers.FindAsync(shareTransfer);                        
            return Response.FAILED;
        }

        public async Task<decimal?> GetSharesByMemberId(Member member)
        {
            try
            {
                var shares = await _sharesidSaccoContext.Shareholders
                    .Where(shareholder => shareholder.MemberId == member.MemberId)
                    .Select(shareholder => shareholder.ShareCount)
                    .FirstOrDefaultAsync();

                return shares;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response> SharesTransferRequest(Member sender_Member, Member receiver_Member, int shares)
        {
            try
            {
                var senderShares = await _sharesidSaccoContext.Shareholders
                    .Where(shareholder => shareholder.MemberId == sender_Member.MemberId)
                    .Select(shareholder => shareholder.ShareCount)
                    .FirstOrDefaultAsync();

                //Condition checks that the sender shares
                //      ->is available
                //      ->is less than or equal to the number of shares being transferred
                //      ->will be greater than or equal to 0 when the shares being transferred will be removed from the sender's shares

                if(senderShares != null && senderShares <= shares && (senderShares - shares) >= 0)
                {
                    //Changes to be made to the sharesTransfer Table and model to accomodate member to member transfer not account to account transfer
                    var shareTransfer = new ShareTransfer
                    {
                        TransferId = Guid.NewGuid(),


                    };
                    await _sharesidSaccoContext.ShareTransfers
                        .AddAsync(shareTransfer);

                    await _sharesidSaccoContext.SaveChangesAsync();

                    return Response.SUCCESS;
                }
                else
                {
                    return Response.FAILED;
                }
            }catch (Exception ex)
            {
                return Response.FAILED;
            }
        }
    }
}
