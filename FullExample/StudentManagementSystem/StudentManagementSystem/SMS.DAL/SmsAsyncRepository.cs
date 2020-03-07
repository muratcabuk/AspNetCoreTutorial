using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Data;
using SMS.Core.Data.Interfaces;

namespace SMS.DAL
{
   public class SmsAsyncRepository<T>: BaseAsyncRepository<T> where T:BaseDataEntity, IDataEntity
    {
        // private readonly IDbContext _dbContext;

        private readonly DbContext _dbContext;

        //  public SmsAsyncRepository(IDbContext dbContext) : base(dbContext)

        public SmsAsyncRepository(DbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
