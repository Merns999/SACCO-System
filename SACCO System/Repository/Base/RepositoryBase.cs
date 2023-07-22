using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Models;
using SACCO_System.Repository.RepositoryBase;

namespace SACCO_System.Repository.Base
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public RepositoryBase(TContext context) => _context = context;

        

    }
}
