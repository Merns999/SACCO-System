using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;
using SACCO_System.Repository.Base;
using System.Data.Entity;

namespace SACCO_System.Repository.Accounts
{
    public class AccountRepository :  RepositoryBase<Account, SharesidSaccoContext>, IAccountRepository
    {
        private readonly SharesidSaccoContext _sharesidSaccoContext;
        public AccountRepository(SharesidSaccoContext sharesidSaccoContext) : base(sharesidSaccoContext)
        {
            _sharesidSaccoContext = sharesidSaccoContext;
        }

        public async Task<LockStatus> CheckLockStatus(Member member)
        {
            var loanStatus = await _sharesidSaccoContext.Accounts
                .Where(account => account.MemberId == member.MemberId)
                .Select(account => account.LockStatus)
                .FirstOrDefaultAsync();

            return (LockStatus)loanStatus;
        }

        public async Task<decimal?> GetBalance(Member member)
        {
            var accBalance = await _sharesidSaccoContext.Accounts
                .Where(account => account.MemberId == member.MemberId)
                .Select(account => account.AccountBalance)
                .FirstOrDefaultAsync();

            return accBalance;
        }

        public async Task<Account> GetMemberAccountDetails(Member member)
        {
            var accDetails = await _sharesidSaccoContext.Accounts
                .Where(account => account.MemberId == member.MemberId)
                .Select(account => account)
                .FirstOrDefaultAsync();

            return accDetails;
        }

        public async Task<Response> MakeDeleteRequest(Member member)
        {
            try
            {
                //Fetch the delete requeest account for a member
                var deleteRequestAccount = await _sharesidSaccoContext.Accounts
                    .Where(account => account.MemberId == member.MemberId)
                    .FirstOrDefaultAsync();

                //Create the Delete Request field then pass it to the delete request table
                var deleteRequest = new DeleteRequest(Guid.NewGuid().ToString() , deleteRequestAccount.AccountNumber, DateTime.UtcNow, deleteRequestAccount);

                var deleteResponse = await _sharesidSaccoContext.DeleteRequests
                    .AddAsync(deleteRequest);

                await _sharesidSaccoContext.SaveChangesAsync();

                return Response.SUCCESS;

            }catch(Exception ex)
            {
                return Response.FAILED;
            }
        }
    }
}
