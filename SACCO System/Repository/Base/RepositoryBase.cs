using Microsoft.EntityFrameworkCore;
using SACCO_System.Data;
using SACCO_System.Models;

namespace SACCO_System.Repository.RepositoryBase
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        protected RepositoryBase(TContext context) => _context = context;

        

    }
}
