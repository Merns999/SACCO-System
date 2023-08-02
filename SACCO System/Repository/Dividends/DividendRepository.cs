using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Dividends
{
    public class DividendRepository : IDividendRepository
    {
        private readonly SharesidSaccoContext _sharesidSaccoContext;

        public DividendRepository(SharesidSaccoContext sharesidSaccoContext) => _sharesidSaccoContext = sharesidSaccoContext;

        public async Task<Response> AddDividend(Dividend dividend)
        {
            try {
                await _sharesidSaccoContext.Dividends
                    .AddAsync(dividend);
                await _sharesidSaccoContext.SaveChangesAsync();

                return Response.SUCCESS;

            }catch (Exception ex)
            {
                return Response.FAILED;
            }
        }

        public async Task<Response> DeleteDividend(Dividend dividend)
        {
            try
            {
                var findDbDividend = await _sharesidSaccoContext.Dividends
                    .FindAsync(dividend);

                if(findDbDividend != null)
                {
                    _sharesidSaccoContext.Dividends
                        .Remove(dividend);
                    await _sharesidSaccoContext.SaveChangesAsync() ;
                    
                    return Response.SUCCESS;
                }
                else
                {
                    return Response.NOT_FOUND;
                }
            }
            catch
            {
                return Response.FAILED;
            }
        }

        public async Task<Response> DeleteMemberDividend(Member member)
        {
            try
            {
                var dividend = await _sharesidSaccoContext.Dividends
                   .Where(dividend => dividend.AccountNumberNavigation.MemberId == member.MemberId)
                   .FirstOrDefaultAsync();

                if (dividend != null) {
                    _sharesidSaccoContext.Dividends
                        .Remove(dividend);

                    await _sharesidSaccoContext.SaveChangesAsync();

                    return Response.SUCCESS;
                }
                else
                {
                    return Response.NOT_FOUND;
                }
            }catch(Exception ex)
            {
                return Response.FAILED;
            }
        }

        public async Task<IEnumerable<Dividend>> GetAllDividends()
        {
            try
            {
                var dividends = await _sharesidSaccoContext.Dividends
                    .ToListAsync();

                return dividends;
            }catch(Exception ex)
            {
                return Enumerable.Empty<Dividend>();
            }
        }

        public Task<DividendCalculationMethod> GetMemberDividendCalculationMethod(Member member)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal?> GetMemberDividendPaymentAmount(Member member)
        {
            try
            {
                var divPay = await _sharesidSaccoContext.Dividends
                    .Where(dividend => dividend.AccountNumberNavigation.MemberId == member.MemberId)
                    .Select(dividend => dividend.Amount)
                    .FirstOrDefaultAsync();

                return divPay;
            }catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Member> GetMemberById(int memberId)
        {
            return await _sharesidSaccoContext.Members.FindAsync(memberId);
        }

        public async Task<string?> GetMemberDividendStatus(Member member)
        {
            try
            {
                var dividendStatus = await _sharesidSaccoContext.Dividends
                    .Where(dividend => dividend.AccountNumberNavigation.MemberId == member.MemberId)
                    .Select(dividend => dividend.DividendStatus)
                    .FirstOrDefaultAsync();

                if (dividendStatus != null) {
                    return dividendStatus;
                }
                else
                {
                    return null;
                }
            }catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> UpdateDividend(Dividend dividend)
        {
            try
            {
                var dbDividend = await _sharesidSaccoContext.Dividends
                    .FindAsync(dividend);

                if(dbDividend != null)
                {
                    dbDividend.AccountNumber = dividend.AccountNumber;
                    dbDividend.Amount = dividend.Amount;
                    dbDividend.TimeStamp = DateTime.UtcNow;
                    dbDividend.DividendStatus = dividend.DividendStatus;
                    dbDividend.DividendCalculationMethod = dividend.DividendCalculationMethod;

                    await _sharesidSaccoContext.SaveChangesAsync();

                    return Response.SUCCESS;
                }
                else
                {
                    return Response.NOT_FOUND;
                }
            }catch(Exception)
            {
                return Response.FAILED;
            }

        }
    }
}
