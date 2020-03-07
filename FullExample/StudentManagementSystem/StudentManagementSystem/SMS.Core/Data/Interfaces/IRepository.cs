using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Data.Interfaces
{
   public interface IRepository<T> where T : IDataEntity
   {

       IEnumerable<T> GetAll();
       IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);

       T GetById(object id);
       T  FirstOrDefault(Expression<Func<T, bool>> predicate);

       int CountAll();
       int CountWhere(Expression<Func<T, bool>> predicate);

       void Insert(T obj);
       void Update(T obj);
       void Delete(object id);
       void Save();







    }
}
