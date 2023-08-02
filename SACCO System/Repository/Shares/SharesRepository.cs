﻿using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Shares
{
    public class SharesRepository : ISharesRepository
    {
        private readonly SharesidSaccoContext _sharesidSaccoContext;

        public SharesRepository(SharesidSaccoContext sharesidSaccoContext) => _sharesidSaccoContext = sharesidSaccoContext;

        //public async Task<Response> ConfirmSharesTransfer(ShareTransfer shareTransfer)
        //{

        //}

        public async Task<decimal?> GetSharesByMemberId(Member member)
        {
            try
            {
                var shares = await _sharesidSaccoContext.Shareholders
                    .Where(shareholder => shareholder.MemberId == member.MemberId)
                    .Select(shareholder => shareholder.ShareCount)
                    .FirstOrDefaultAsync();

                return shares;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> SharesTransferRequest(Member sender_Member, Member receiver_Member, decimal shares)
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

                if (senderShares != null && senderShares <= shares && (senderShares - shares) >= 0)
                {
                    var shareTransfer = new ShareTransfer
                    {
                        TransferId = Guid.NewGuid().ToString(),
                        SenderMemberID = sender_Member.MemberId,
                        ReceiverMemberID = receiver_Member.MemberId,
                        ShareCount = senderShares,
                        TimeStamp = DateTime.Now
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
            }
            catch (Exception)
            {
                return Response.FAILED;
            }
        }
    }
}
