using SACCO_System.Enumerables;
using SACCO_System.Models;
using SACCO_System.Repository.RepositoryBase;

namespace SACCO_System.Repository.Members
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberByID(int memberId);
        Task<IEnumerable<Member>> GetAllMembers();
        Task<Response> AddMember(Member member);
        Task<Response> UpdateMember(Member member);
        Task<Response> DeleteMember(Member member);
        Task<object> GetMemberDetails(Member member);
        Task<object> GetMemberByName(Member member);
    }
}
