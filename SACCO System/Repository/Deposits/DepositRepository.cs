﻿using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Deposits
{
    public class DepositRepository : IDepositRepository
    {
        private readonly SharesidSaccoContext _sharesidContext;

        public DepositRepository(SharesidSaccoContext sharesidContext) => _sharesidContext = sharesidContext;

        public async Task<string> GetDepositTransactionStatus(Deposit deposit)
        {
            var transactionStatus = await _sharesidContext.Deposits
                .Where(depo => depo.DepositId == deposit.DepositId)
                .Select(depo => depo.TransactionStatus)
                .FirstOrDefaultAsync();

            if(transactionStatus != null)
            {
                return transactionStatus;
            }
            else
            {
                return "Not Found";
            }
        }
        public async Task<Deposit> GetDepositById(int depositId)
        {
            return await _sharesidContext.Deposits.FindAsync(depositId);
        }
        public async Task<TransactionStatus> MakeDepositRequest(Deposit deposit)
        {
            try
            {
                await _sharesidContext.Deposits
                    .AddAsync(deposit);

                await _sharesidContext.SaveChangesAsync();

                return TransactionStatus.PENDING;
            }
            catch
            {
                return TransactionStatus.REJECTED;
            }
        }
    }
}
