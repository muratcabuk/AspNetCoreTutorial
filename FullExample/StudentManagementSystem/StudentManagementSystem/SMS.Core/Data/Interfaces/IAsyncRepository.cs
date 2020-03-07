using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Core.Data.Interfaces
{
   public interface IAsyncRepository<T> where T : IDataEntity
   {
       Task<IEnumerable<T>> GetAll();
       Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

       Task<T> GetById(object id);
       Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

       Task<int> CountAll();
       Task<int> CountWhere(Expression<Func<T, bool>> predicate);

       Task<int> Insert(T obj);
       Task Update(T obj);
       Task Delete(T obj);
       Task<int> Save(CancellationToken cancellationToken = default(CancellationToken));






    }
}
