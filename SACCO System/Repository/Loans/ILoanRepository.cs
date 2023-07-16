using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Loans
{
    public interface ILoanRepository
    {
        Task<Response> MakeLoanApplication(LoanApplication loanApplication);
        Task<Loan> GetLoanDetails(Member member);
        Task<IEnumerable<Member>> GetLoanGuarantors(Member member);
        Task<string?> GetLoanApplicationStatus(Member member);
        Task<Response> SetReasonForLoanRejection(Member member, string reason);
    }
}
