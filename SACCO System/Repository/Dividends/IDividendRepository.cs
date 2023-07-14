using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Dividends
{
    public interface IDividendRepository
    {
        Task<DividendStatus> GetMemberDividendStatus(Member member);
        Task<DividendCalculationMethod> GetMemberDividendCalculationMethod(Member member);
        Task<Decimal> GetMemberDividendPaymentAmount(Member member);
        Task<Dividend> GetAllDividends();
        Task<Response> AddDividend(Dividend dividend);
        Task<Response> UpdateDividend(Dividend dividend);
        Task<Response> DeleteDividend(Dividend dividend);
        Task<Response> DeleteMemberDividend(Member member);
        Task<Decimal> GetDividendPayments(Member member);

    }
}
