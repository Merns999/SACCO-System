using Microsoft.AspNetCore.Mvc;
using SACCO_System.Models;
using SACCO_System.Repository.Wrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SACCO_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public LoansController(RepositoryWrapper repositoryWrapper) => this.repositoryWrapper = repositoryWrapper;

        private Member CreateMemberWithId(int memberId)
        {
            return new Member { MemberId = memberId };
        }

        [HttpGet, Route("api/Loans/GetLoanApplicationStatus/{memberId}")]
        public async Task<IActionResult> GetLoanApplicationStatus(int memberId)
        {
            try
            {
                var member = CreateMemberWithId(memberId);
                var loanApplicationStatus = await repositoryWrapper.LoanRepository.GetLoanApplicationStatus(member);

                if (loanApplicationStatus is string)
                {
                    return Ok(loanApplicationStatus);
                }
                else
                {
                    return NotFound("Loan application status not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("api/Loans/GetLoanDetails/{memberId}")]
        public async Task<IActionResult> GetLoanDetails(int memberId)
        {
            try
            {
                var member = CreateMemberWithId(memberId);
                var loanDetails = await repositoryWrapper.LoanRepository.GetLoanDetails(member);

                if (loanDetails is Loan)
                {
                    return Ok(loanDetails);
                }
                else
                {
                    return NotFound("Loan details not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("api/Loans/GetLoanGuarantors/{memberId}")]
        public async Task<IActionResult> GetLoanGuarantors(int memberId)
        {
            try
            {
                var member = CreateMemberWithId(memberId);
                var guarantors = await repositoryWrapper.LoanRepository.GetLoanGuarantors(member);

                if (guarantors is IEnumerable<Member>)
                {
                    return Ok(guarantors);
                }
                else
                {
                    return NotFound("Guarantors not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost, Route("api/Loans/MakeLoanApplication")]
        public async Task<IActionResult> MakeLoanApplication([FromBody] LoanApplication loanApplication)
        {
            try
            {
                var response = await repositoryWrapper.LoanRepository.MakeLoanApplication(loanApplication);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Loan application submitted successfully.");
                }
                else
                {
                    return BadRequest("Failed to submit loan application.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost, Route("api/Loans/SetReasonForLoanRejection/{memberId}")]
        public async Task<IActionResult> SetReasonForLoanRejection(int memberId, [FromBody] string reason)
        {
            try
            {
                var member = CreateMemberWithId(memberId);
                var response = await repositoryWrapper.LoanRepository.SetReasonForLoanRejection(member, reason);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Reason for loan rejection set successfully.");
                }
                else
                {
                    return NotFound("Loan application not found or already approved/rejected.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

