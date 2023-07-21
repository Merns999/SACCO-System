using System.Linq.Expressions;
using SACCO_System.Models;

namespace SACCO_System.Repository.RepositoryBase
{
    public interface IRepositoryBase<T> where T : class, IEntity
    {
        //Task<List<T>> GetAllAsync();
        //Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        //Task<T> Add (T entity);
        //Task<T> Update (T entity);
        //Task<T> UpdateByConditionAsync(Expression<Func<T, bool>> expression);
        //Task<T> Delete(T entity);
    }
}
