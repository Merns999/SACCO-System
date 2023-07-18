using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;
using System.Data.Entity;

namespace SACCO_System.Repository.Loans
{
    public class LoanRepository : ILoanRepository
    {
        private readonly SharesidSaccoContext _sharesidSaccoContext;

        public LoanRepository(SharesidSaccoContext sharesidSaccoContext) => _sharesidSaccoContext = sharesidSaccoContext;

        public async Task<string?> GetLoanApplicationStatus(Member member)
        {
            try
            {
                var loanApplicationStatus = await _sharesidSaccoContext.LoanApplications
                    .Where(application => application.MemberId == member.MemberId)
                    .Select(application => application.ApplicationStatus)
                    .FirstOrDefaultAsync();

                if (loanApplicationStatus != null)
                {
                    return loanApplicationStatus;
                }
                else
                {
                    return null;
                }
            }catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<Loan> GetLoanDetails(Member member)
        {
            try
            {
                var loanApplicationForMember = await _sharesidSaccoContext.LoanApplications
                    .Where(application => application.MemberId == member.MemberId)
                    .FirstOrDefaultAsync();
                
                //If the member had a loan application we can check for whether it was approved or not then give the loan details
                if(loanApplicationForMember.ApplicationStatus == "APPROVED")
                {
                    var loan = await _sharesidSaccoContext.Loans
                        .Where(loanDetails => loanDetails.LoanApplicationId == loanApplicationForMember.LoanApplicationId)
                        .FirstOrDefaultAsync();
                    
                    return loan;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Member>> GetLoanGuarantors(Member member)
        {
            try
            {
                var loanApplicationForMember = await _sharesidSaccoContext.LoanApplications
                    .Where(application => application.MemberId == member.MemberId)
                    .FirstOrDefaultAsync();

                if (loanApplicationForMember.ApplicationStatus == "APPROVED")
                {
                    var loan = await _sharesidSaccoContext.Loans
                        .Where(loanDetails => loanDetails.LoanApplicationId == loanApplicationForMember.LoanApplicationId)
                        .FirstOrDefaultAsync();

                    var guarantors = await _sharesidSaccoContext.Guarantors
                        .Where(guarantor => guarantor.Loan.LoanId == loan.LoanId)
                        .ToListAsync();

                    List<Member> members = new List<Member>();

                    foreach (Guarantor guarantor in guarantors) {
                        var GuarantorDetails = await _sharesidSaccoContext.Members
                            .Where(mem => mem.MemberId == guarantor.MemberId)
                            .FirstOrDefaultAsync();

                        members.Add(GuarantorDetails);
                    }

                    return members;
                }
                else
                {
                    return null;
                }
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response> MakeLoanApplication(LoanApplication loanApplication)
        {
            try
            {
                await _sharesidSaccoContext.LoanApplications.AddAsync(loanApplication);
                await _sharesidSaccoContext.SaveChangesAsync();

                return Response.SUCCESS;

            }catch (Exception ex)
            {
                return Response.FAILED;
            }
        }

        public async Task<Response> SetReasonForLoanRejection(Member member, string reason)
        {
            var loanApplicationForMember = await _sharesidSaccoContext.LoanApplications
                    .Where(application => application.MemberId == member.MemberId)
                    .FirstOrDefaultAsync();

            if (loanApplicationForMember.ApplicationStatus == "PENDING")
            {
                loanApplicationForMember.ApplicationStatus = "REJECTED";
                loanApplicationForMember.ReasonForRejection = reason;

                return Response.SUCCESS;
            }
            else
            {
                return Response.FAILED;
            }
        }
    }
}
