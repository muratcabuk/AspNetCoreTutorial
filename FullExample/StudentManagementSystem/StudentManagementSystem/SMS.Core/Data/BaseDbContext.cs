
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SMS.Core.Data.Interfaces;

namespace SMS.Core.Data
{
    public class BaseDbContext : DbContext//, IDbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options): base(options)
        {

            

        }


        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}




      //  public int SaveChanges(bool acceptAllChangesOnSuccess)
      // {
      //     return base.SaveChanges(acceptAllChangesOnSuccess);


      // }


      // public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
      // {
      //     return await base.SaveChangesAsync(cancellationToken);
      // }

      //public  async Task<int> SaveChangesAsync(
      //     bool acceptAllChangesOnSuccess,
      //     CancellationToken cancellationToken = default(CancellationToken))
      //{

      //    return await SaveChangesAsync(cancellationToken);

      //}

        
      //  public DbSet<TEntity> Set<TEntity>() where TEntity : class, IDataEntity
      //  {
      //      return base.Set<TEntity>();
      //  }




      //  public EntityEntry Entry(object entity)
      //  {

      //      base.Entry(entity);

      //  }

      // public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class, IDataEntity
      // {

      //     base.Entry<TEntity>(entity);

      // }



    }
}
