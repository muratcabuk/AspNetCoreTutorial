using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace SMS.Core.Data.Interfaces
{
    public interface IDbContext: IDisposable, IAsyncDisposable, 
                    IInfrastructure<IServiceProvider>, IDbContextDependencies, 
                    IDbSetCache, IDbContextPoolable //, IResettableService
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        
            
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken));


        EntityEntry Entry(object entity);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;



    }
}
