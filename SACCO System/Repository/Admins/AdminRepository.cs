using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Enumerables;
using SACCO_System.Models;
using System.Data.Entity;

namespace SACCO_System.Repository.Admins
{
    public class AdminRepository : IAdminRepository
    {
        private SharesidSaccoContext _sharesidSaccoContext;

        public AdminRepository(SharesidSaccoContext sharesidSaccoContext) => _sharesidSaccoContext = sharesidSaccoContext;

        public async Task<Response> AddAdministrator(Admin admin)
        {
            try
            {
                await _sharesidSaccoContext.Admins
                    .AddAsync(admin);

                await _sharesidSaccoContext.SaveChangesAsync();

                return Response.SUCCESS;

            }catch (Exception ex)
            {
                return Response.FAILED;
            }
        }

        public async Task<Admin> GetAdministrator(Admin admin)
        {
            var fetchedAdmin = await _sharesidSaccoContext.Admins
                .Where(admin => admin.Equals(admin))
                .FirstOrDefaultAsync();

            return fetchedAdmin;
        }

        public async Task<IEnumerable<Admin>> GetAdmins()
        {
            var fetchedAdmins = await _sharesidSaccoContext.Admins
                .ToListAsync();

            return fetchedAdmins;
        }

        public async Task<Response> RemoveAdministrator(Admin admin)
        {
            try
            {
                var adminToRemove = await _sharesidSaccoContext.Admins
                    .FindAsync(admin.AdminId);

                if(adminToRemove != null)
                {
                    _sharesidSaccoContext.Admins
                        .Remove(admin);

                    await _sharesidSaccoContext.SaveChangesAsync();
                }

                return Response.SUCCESS;
                
            }catch (Exception ex)
            {
                return Response.FAILED;
            }
        }

        public async Task<Response> UpdateAdministrator(Admin admin)
        {
            try
            {
                var adminToUpdate = await _sharesidSaccoContext.Admins
                        .FindAsync(admin.AdminId);

                if (adminToUpdate != null)
                {
                    adminToUpdate.Name = admin.Name;
                    adminToUpdate.Email = admin.Email;
                    adminToUpdate.Password = admin.Password;
                    adminToUpdate.PhoneNumber = admin.PhoneNumber;

                    await _sharesidSaccoContext.SaveChangesAsync();
                }

                return Response.SUCCESS;
            }catch(Exception ex) 
            {
                return Response.FAILED;
            }
        }
    }
}
