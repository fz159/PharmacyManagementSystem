using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.DAL.DataAccess.Interface
{
    public interface IRepo<T> where T : class
    {
        
        void Addsync(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void updateExisting(T entity);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetFirstorDefaultAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllListAsync(Expression<Func<T, bool>> filter);
    }
}
