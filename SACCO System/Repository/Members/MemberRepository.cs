using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Members
{
    public class MemberRepository : IMemberRepository
    {
        private readonly SharesidSaccoContext _sharesidSaccoContext;
        public MemberRepository(SharesidSaccoContext sharesidSaccoContext) => _sharesidSaccoContext = sharesidSaccoContext;

        public async Task<Response> AddMember(Member member)
        {
            try
            {
                await _sharesidSaccoContext.Members
                    .AddAsync(member);

                await _sharesidSaccoContext.SaveChangesAsync();

                return Response.SUCCESS;

            }catch(Exception)
            {
                return Response.FAILED;
            }
        }

        public async Task<Response> DeleteMember(Member member)
        {
            try
            {
                var memToDelete = await _sharesidSaccoContext.Members
                    .FindAsync(member);

                if(member != null) 
                {
                    _sharesidSaccoContext.Members
                         .Remove(member);

                    await _sharesidSaccoContext.SaveChangesAsync();
                }

                return Response.SUCCESS;

            }catch(Exception)
            {
                return Response.FAILED;
            }
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            var members =  await _sharesidSaccoContext.Members
                .ToListAsync();

            return members;
        }

        public async Task<Member> GetMemberByID(int memberId)
        {
            var dbMember = await _sharesidSaccoContext.Members
                .Where(member => member.MemberId == memberId)
                .FirstOrDefaultAsync();
            if (dbMember == null)
            {
                throw new ArgumentException($"Member with ID {memberId} not found.");
            }
            else
            {
                return dbMember;
            }
        }     

        public async Task<object> GetMemberByName(Member member)
        {
            var dbmember = await _sharesidSaccoContext.Members
                .Where(mem => mem.Name == member.Name)
                .FirstOrDefaultAsync();

            if(dbmember != null)
            { 
                return dbmember; 
            }
            else
            {
                return "Member not Found";
            }   
        }

        public async Task<object> GetMemberDetails(Member member)
        {
            var dbmember = await _sharesidSaccoContext.Members
                .FindAsync(member.MemberId);

            if(dbmember != null)
            {
                return dbmember;
            }
            else
            {
                return "Member not Found";
            }
        }

        public async Task<Response> UpdateMember(Member member)
        {
            var dbmember = await _sharesidSaccoContext.Members
                .FindAsync(member.MemberId);

            if(dbmember != null )
            {
                dbmember.Name = member.Name;
                dbmember.PhoneNumber= member.PhoneNumber;
                dbmember.Email= member.Email;
                dbmember.DateOfBirth = member.DateOfBirth;
                dbmember.Address = member.Address;
                dbmember.Occupation = member.Occupation;
                dbmember.Password = member.Password;

                await _sharesidSaccoContext.SaveChangesAsync();

                return Response.SUCCESS;
            }
            else
            {
                return Response.FAILED;
            }
        }

        
    }
}

