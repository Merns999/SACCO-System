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
    public class MemberController : ControllerBase
    {
        private readonly RepositoryWrapper repositoryWrapper;

        public MemberController(RepositoryWrapper repositoryWrapper) => this.repositoryWrapper = repositoryWrapper;

        private Member CreateMemberWithId(int memberId)
        {
            return new Member { MemberId = memberId };
        }

        [HttpPost, Route("api/Member/AddMember")]
        public async Task<IActionResult> AddMember([FromBody] Member member)
        {
            try
            {
                var response = await repositoryWrapper.MemberRepository.AddMember(member);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Member added successfully.");
                }
                else
                {
                    return BadRequest("Failed to add the member.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("api/Member/GetAllMembers")]
        public async Task<IActionResult> GetAllMembers()
        {
            try
            {
                var members = await repositoryWrapper.MemberRepository.GetAllMembers();
                return Ok(members);
            }
            catch (Exception )
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("api/Member/GetMemberById /{memberId}")]
        public async Task<IActionResult> GetMemberById(int memberId)
        {
            try
            {
                var memberDetails = await repositoryWrapper.MemberRepository.GetMemberByID(memberId);

                if (memberDetails is Member)
                {
                    return Ok(memberDetails);
                }
                else
                {
                    return NotFound("Member not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("api/Member/GetMemberByName/{name}")]
        public async Task<IActionResult> GetMemberByName(string name)
        {
            try
            {
                var member = new Member { Name = name };
                var memberDetails = await repositoryWrapper.MemberRepository.GetMemberByName(member);

                if (memberDetails is Member)
                {
                    return Ok(memberDetails);
                }
                else
                {
                    return NotFound("Member not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet, Route("api/Member/GetMemberDetails/{memberId}")]
        public async Task<IActionResult> GetMemberDetails(int memberId)
        {
            try
            {
                var member = CreateMemberWithId(memberId);
                var memberDetails = await repositoryWrapper.MemberRepository.GetMemberDetails(member);

                if (memberDetails is Member)
                {
                    return Ok(memberDetails);
                }
                else
                {
                    return NotFound("Member not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut, Route("api/Member/UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromBody] Member member)
        {
            try
            {
                var dbMember = CreateMemberWithId(member.MemberId);
                var response = await repositoryWrapper.MemberRepository.UpdateMember(dbMember);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Member updated successfully.");
                }
                else
                {
                    return NotFound("Member not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete, Route("api/Member/DeleteMember/{memberId}")]
        public async Task<IActionResult> DeleteMember(int memberId)
        {
            try
            {
                var member = CreateMemberWithId(memberId);
                var response = await repositoryWrapper.MemberRepository.DeleteMember(member);

                if (response == Enumerables.Response.SUCCESS)
                {
                    return Ok("Member deleted successfully.");
                }
                else
                {
                    return NotFound("Member not found.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

