using Microsoft.AspNetCore.Mvc;
using SACCO_System.Enumerables;
using SACCO_System.Models;
using SACCO_System.Repository.Wrapper;


namespace SACCO_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositsController : ControllerBase
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public DepositsController(RepositoryWrapper repositoryWrapper) => this.repositoryWrapper = repositoryWrapper;

        [HttpGet]
        [Route("api/Deposits/GetDepositTransactionStatus/{depositId}")]
        public async Task<ActionResult<string>> GetDepositTransactionStatus(int depositId)
        {
            try
            {
                var deposit = await repositoryWrapper.DepositRepository.GetDepositById(depositId);
                var transactionStatus = await repositoryWrapper.DepositRepository.GetDepositTransactionStatus(deposit);

                if (transactionStatus != "Not Found")
                {
                    return Ok(transactionStatus);
                }
                else
                {
                    return NotFound("Deposit transaction not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("api/Deposits/MakeDepositRequest")]
        public async Task<IActionResult> MakeDepositRequest([FromBody] Deposit deposit)
        {
            try
            {
                var transactionStatus = await repositoryWrapper.DepositRepository.MakeDepositRequest(deposit);

                if (transactionStatus == TransactionStatus.PENDING)
                {
                    return Ok("Deposit request made successfully.");
                }
                else
                {
                    return BadRequest("Failed to make the deposit request.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
