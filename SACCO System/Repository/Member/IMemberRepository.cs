using SACCO_System.Enumerables;
using SACCO_System.Models;
using SACCO_System.Repository.RepositoryBase;

namespace SACCO_System.Repository.MemberRepository
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberByID(Member member);
        Task<IEnumerable<Member>> GetAllMembers();
        Task<Member> AddMember(Member member);
        Task<Response> UpdateMember(Member member);
        Task<Response> DeleteMember(Member member);
        Task<Member> GetMemberDetails(Member member);
        Task<Member> GetMemberByName(Member member);
    }
}
