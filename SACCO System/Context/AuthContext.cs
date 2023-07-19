using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;

namespace SACCO_System.Context
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions<SharesidSaccoContext> options) : base(options)
        {
        }
    }
}
