using SACCO_System.Enumerables;
using SACCO_System.Models;

namespace SACCO_System.Repository.Admins
{
    public interface IAdminRepository
    {
        Task<Response> AddAdministrator(Admin admin);
        Task<Response> RemoveAdministrator(Admin admin);
        Task<Response> UpdateAdministrator(Admin admin);
        Task<Admin> GetAdministrator(Admin admin);
        Task<IEnumerable<Admin>> GetAdmins();
    }
}
