using Microsoft.AspNetCore.Mvc;
using SACCO_System.Models;
using SACCO_System.Repository.Wrapper;
using System;
using System.Threading.Tasks;

namespace SACCO_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharesController : ControllerBase
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public SharesController(RepositoryWrapper repositoryWrapper) => this.repositoryWrapper = repositoryWrapper;

        private Member CreateMemberWithId(int memberId)
        {
            return new Member { MemberId = memberId };
        }

        [HttpGet, Route("api/Shares/GetSharesByMemberId/{memberId}")]
        public async Task<IActionResult> GetSharesByMemberId(int memberId)
        {
            try
            {
                var member = CreateMemberWithId(memberId);
                var shares = await repositoryWrapper.SharesRepository.GetSharesByMemberId(member);

                if (shares is decimal)
                {
                    return Ok(shares);
                }
                else
                {
                    return NotFound("Shares not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost, Route("api/Shares/SharesTransferRequest")]
        public async Task<IActionResult> SharesTransferRequest([FromBody] ShareTransfer request)
        {

            try
            {
                var senderMember = await repositoryWrapper.MemberRepository.GetMemberByID(request.SenderMemberID ?? 0);
                var receiverMember = await repositoryWrapper.MemberRepository.GetMemberByID(request.ReceiverMemberID ?? 0);

                if (senderMember == null)
                {
                    return NotFound("Sender is not a member of the SACCO.");
                }

                if (receiverMember == null)
                {
                    return NotFound("Receiver is not a member of the SACCO.");
                }

                var response = await repositoryWrapper.SharesRepository.SharesTransferRequest(senderMember, receiverMember, request.ShareCount ?? 0);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Shares transfer request submitted successfully.");
                }
                else
                {
                    return BadRequest("Failed to submit shares transfer request.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

