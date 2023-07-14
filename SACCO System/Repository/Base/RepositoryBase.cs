using SACCO_System.Data;

namespace SACCO_System.Repository.RepositoryBase
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        protected SharesidSaccoContext _context { get; set; }

        public RepositoryBase(SharesidSaccoContext context) => _context = context; 



    }
}
