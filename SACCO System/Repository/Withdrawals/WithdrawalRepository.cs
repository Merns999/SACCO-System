using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Withdrawals
{
    public class WithdrawalRepository : IWithdrawalRepository
    {
        private readonly SharesidSaccoContext _sharesidSaccoContext;

        public WithdrawalRepository(SharesidSaccoContext sharesidSaccoContext) => _sharesidSaccoContext = sharesidSaccoContext;

        public async Task<string?> CheckWithdrawalTransactionStatus(Member member)
        {
            //A member has many accounts so we have to go through the collection of accounts for a member and see if any of it has a withdrawal pending

            string? transactionStatus = null;

            foreach (Account account in member.Accounts) {
                 transactionStatus = await _sharesidSaccoContext.Withdrawals
                    .Where(mem => mem.AccountNumber == account.AccountNumber)
                    .Select(mem => mem.TransactionStatus)
                    .FirstOrDefaultAsync();
            }

            if(transactionStatus != null)
            {
                return transactionStatus;
            }

            return "NOT_FOUND"; 
        }

        public async Task<Response> MakeWithdrawalRequest(Withdrawal request)
        {
            try
            {
                await _sharesidSaccoContext.Withdrawals
                    .AddAsync(request);

                await _sharesidSaccoContext.SaveChangesAsync();

                return Response.SUCCESS;

            }catch(Exception ex)
            {
                return Response.FAILED;
            }
        }
    }
}
