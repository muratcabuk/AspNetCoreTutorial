using System;
using System.Reflection;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using SMS.BL;
using SMS.BL.Domain.General;
using SMS.BL.Domain.Student;
using SMS.BL.Domain.Teacher;
using SMS.BL.Infra;
using SMS.Core;
using SMS.Core.Interfaces;
using SMS.Core.Multiculture;

namespace Microsoft.Extensions.DependencyInjection.Extensions
{
    public static class BlServiceCollection
    {
        public static IServiceCollection AddBlServices(this IServiceCollection services)
        {


            services.AddTransient<IStudentManager, StudentManager>();
            services.AddTransient<ITeacherManager, TeacherManager>();
            services.AddTransient<IOptionManager, OptionManager>();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

           // services.AddAutoMapper(typeof(BlMappingProfile));


            services.AddLazyCache();

            //services.AddDbContext<IDbContext, SmsDbContext>();


            return services;

        }

    }
}
