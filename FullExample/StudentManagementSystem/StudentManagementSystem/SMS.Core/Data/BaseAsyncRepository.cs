using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Data.Interfaces;

namespace SMS.Core.Data
{
    public  class BaseAsyncRepository<T> : IAsyncRepository<T> where T: BaseDataEntity, IDataEntity
    {

        //private readonly IDbContext _dbContext;
        private readonly DbContext _dbContext;

       // public BaseAsyncRepository(IDbContext dbContext)

        public BaseAsyncRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync(); ;

        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync(); 
        }

        public async Task<T> GetById(object id)
        {
           return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAll()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).CountAsync();

        }

        public async Task<int> Insert(T obj)
        {
          var t = await  _dbContext.Set<T>().AddAsync(obj);

          return t.Entity.Id;


        }

        public async Task Update(T obj)
        {
            var t = await _dbContext.Set<T>().FindAsync(obj.Id);
            _dbContext.Entry(t).CurrentValues.SetValues(obj);
        }

        public async Task Delete(T obj)
        {
           await Task.Run(() => _dbContext.Set<T>().Remove(obj));
        }

        public async Task<int> Save(CancellationToken cancellationToken = default(CancellationToken))
        {
           return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
