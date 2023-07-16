using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Dividends
{
    public interface IDividendRepository
    {
        Task<string?> GetMemberDividendStatus(Member member);
        Task<DividendCalculationMethod> GetMemberDividendCalculationMethod(Member member);
        Task<decimal?> GetMemberDividendPaymentAmount(Member member);
        Task<IEnumerable<Dividend>> GetAllDividends();
        Task<Response> AddDividend(Dividend dividend);
        Task<Response> UpdateDividend(Dividend dividend);
        Task<Response> DeleteDividend(Dividend dividend);
        Task<Response> DeleteMemberDividend(Member member);

    }
}
