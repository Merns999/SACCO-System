using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SACCO_System.Enumerables;
using SACCO_System.Models;
using SACCO_System.Repository.Wrapper;

namespace SACCO_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly RepositoryWrapper repositoryWrapper;
        public AccountsController(RepositoryWrapper repositoryWrapper) => this.repositoryWrapper = repositoryWrapper;


        [HttpGet]
        [Route("CheckLockStatus/{memberId}")]
        public async Task<ActionResult<LockStatus>> CheckLockStatus(int memberId)
        {
            try
            {
                var member = new Member { MemberId = memberId };
                var lockStatus = await repositoryWrapper.AccountRepository.CheckLockStatus(member);
                return Ok(lockStatus);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("GetBalance/{memberId}")]
        public async Task<ActionResult<decimal?>> GetBalance(int memberId)
        {
            try
            {
                var member = new Member { MemberId = memberId };
                var balance = await repositoryWrapper.AccountRepository.GetBalance(member);
                return Ok(balance);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("GetMemberAccountDetails/{memberId}")]
        public async Task<ActionResult<Account>> GetMemberAccountDetails(int memberId)
        {
            try
            {
                var member = new Member { MemberId = memberId };
                var accountDetails = await repositoryWrapper.AccountRepository.GetMemberAccountDetails(member);
                return Ok(accountDetails);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("MakeDeleteRequest/{memberId}")]
        public async Task<IActionResult> MakeDeleteRequest(int memberId)
        {
            try
            {
                var member = new Member { MemberId = memberId };
                var response = await repositoryWrapper.AccountRepository.MakeDeleteRequest(member);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Delete request made successfully.");
                }
                else
                {
                    return BadRequest("Failed to make the delete request.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
  }
}


