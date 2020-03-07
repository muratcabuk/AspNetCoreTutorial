using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Data;
using SMS.Core.Data.Interfaces;
using SMS.DAL;

namespace Microsoft.Extensions.DependencyInjection.Extensions
{

    public static class DalServiceCollection
    {

        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            //services.AddDbContext<IDbContext, SmsDbContext>(
            //    options => options.UseInMemoryDatabase(Configuration["ConnectionStrings:InMemoryConnection"]));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(SmsAsyncRepository<>));


            return services;

        }
    }
}
