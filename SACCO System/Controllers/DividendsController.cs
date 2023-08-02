using Microsoft.AspNetCore.Mvc;
using SACCO_System.Enumerables;
using SACCO_System.Models;
using SACCO_System.Repository.Wrapper;


namespace SACCO_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DividendsController : ControllerBase
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public DividendsController(RepositoryWrapper repositoryWrapper) => this.repositoryWrapper = repositoryWrapper;

        [HttpPost, Route("AddDividend")]
        public async Task<IActionResult> AddDividend([FromBody] Dividend dividend)
        {
            try
            {
                var response = await repositoryWrapper.DividendRepository.AddDividend(dividend);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Dividend added successfully.");
                }
                else
                {
                    return BadRequest("Failed to add the dividend.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete, Route("DeleteDividend")]
        public async Task<IActionResult> DeleteDividend([FromBody] Dividend dividend)
        {
            try
            {
                var response = await repositoryWrapper.DividendRepository.DeleteDividend(dividend);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Dividend deleted successfully.");
                }
                else if (response == Enumerables.Response.NOT_FOUND)
                {
                    return NotFound("Dividend not found.");
                }
                else
                {
                    return BadRequest("Failed to delete the dividend.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete, Route("DeleteMemberDividend /{memberId}")]
        public async Task<IActionResult> DeleteMemberDividend(int memberId)
        {
            try
            {
                var member = new Member { MemberId = memberId };
                var response = await repositoryWrapper.DividendRepository.DeleteMemberDividend(member);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Member dividend deleted successfully.");
                }
                else if (response == Enumerables.Response.NOT_FOUND)
                {
                    return NotFound("Member dividend not found.");
                }
                else
                {
                    return BadRequest("Failed to delete the member dividend.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("GetAllDividends")]
        public async Task<ActionResult<IEnumerable<Dividend>>> GetAllDividends()
        {
            try
            {
                var dividends = await repositoryWrapper.DividendRepository.GetAllDividends();
                return Ok(dividends);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("GetMemberDividendPaymentAmount/{memberId}")]
        public async Task<ActionResult<decimal?>> GetMemberDividendPaymentAmount(int memberId)
        {
            try
            {
                var member = await repositoryWrapper.DividendRepository.GetMemberById(memberId);
                var dividendPaymentAmount = await repositoryWrapper.DividendRepository.GetMemberDividendPaymentAmount(member);
                return Ok(dividendPaymentAmount);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("GetMemberDividendStatus /{memberId}")]
        public async Task<ActionResult<string>> GetMemberDividendStatus(int memberId)
        {
            try
            {
                var member = await repositoryWrapper.DividendRepository.GetMemberById(memberId);
                var dividendStatus = await repositoryWrapper.DividendRepository.GetMemberDividendStatus(member);
                return Ok(dividendStatus);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut, Route("UpdateDividend")]
        public async Task<Response> UpdateDividend(Dividend dividend)
        {
            try
            {
                var dbDividend = await repositoryWrapper.DividendRepository.UpdateDividend(dividend);

                if (dbDividend != null)
                {
                   repositoryWrapper.Save();

                   return Enumerables.Response.SUCCESS;
                }
                else
                {
                    return Enumerables.Response.NOT_FOUND;
                }
            }
            catch (Exception)
            {
                return Enumerables.Response.FAILED;
            }
        }
    }
}

