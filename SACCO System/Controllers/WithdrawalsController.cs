using Microsoft.AspNetCore.Mvc;
using SACCO_System.Models;
using SACCO_System.Repository.Wrapper;
using System;
using System.Threading.Tasks;

namespace SACCO_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawalsController : ControllerBase
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public WithdrawalsController(RepositoryWrapper repositoryWrapper) => this.repositoryWrapper = repositoryWrapper;
     

        private Member CreateMemberWithId(int memberId)
        {
            return new Member { MemberId = memberId };
        }

        [HttpGet, Route("CheckWithdrawalTransactionStatus/{memberId}")]
        public async Task<IActionResult> CheckWithdrawalTransactionStatus(int memberId)
        {
            try
            {
                var member = CreateMemberWithId(memberId);
                var transactionStatus = await repositoryWrapper.WithdrawalRepository.CheckWithdrawalTransactionStatus(member);

                if (transactionStatus != "NOT_FOUND")
                {
                    return Ok(transactionStatus);
                }
                else
                {
                    return NotFound("Withdrawal transaction not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost, Route("MakeWithdrawalRequest")]
        public async Task<IActionResult> MakeWithdrawalRequest([FromBody] Withdrawal withdrawal)
        {
            try
            {
                var response = await repositoryWrapper.WithdrawalRepository.MakeWithdrawalRequest(withdrawal);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Withdrawal request submitted successfully.");
                }
                else
                {
                    return BadRequest("Failed to submit withdrawal request.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
