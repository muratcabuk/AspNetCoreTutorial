using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using FluentSpecification.Abstractions.Validation;
using LazyCache;
using SMS.BL.Domain;
using SMS.BL.Domain.Teacher;
using SMS.Core.Data.Interfaces;
using SMS.Core.Interfaces;
using SMS.Core.Multiculture;
using SMS.Core.Result;
using SMS.DAL.Entities;
using SMS.Globalizaiton.Resources;


namespace SMS.BL
{
    public class TeacherManager : BaseManagement, ITeacherManager
    {

        private readonly IAsyncRepository<Teacher> _asyncTeacherRepository;
        private readonly IMapper _mapper;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IAppCache _cache;

        public TeacherManager(IAsyncRepository<Teacher> asyncTeacherRepository,
                                    IMapper mapper,
                                    IDateTimeProvider dateTimeProvider,
                                    IAppCache cache)
        {
            _asyncTeacherRepository = asyncTeacherRepository;
            _mapper = mapper;
            _dateTimeProvider = dateTimeProvider;
            _cache = cache;
        }

        public async Task<ResultSpec<int>> Add(TeacherAddUpdateModel teacherAddUpdateModel)
        {

            var today = await _dateTimeProvider.GetTodayDateTime();

            var specResult = TeacherAddUpdateSpec.IsSatisfiedBy(teacherAddUpdateModel, 18, today);


            if (specResult.OverallResult)
            {
                using (var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    var teacher = _mapper.Map<Teacher>(teacherAddUpdateModel.Teacher);

                    var newTeacherId = await _asyncTeacherRepository.Insert(teacher);

                    await _asyncTeacherRepository.Save();

                    scope.Complete();

                    return Results.WithOkSpec<int>(newTeacherId).AddMessage(Resource.Successful).AddSpec(new SpecificationResult());
                }
            }
            else
            {
                return Results.WithFailSpec<int>(-1).AddSpec(specResult);
            }
        }


        public async Task<ResultSpec<bool>> Update(TeacherAddUpdateModel teacherAddUpdateModel)
        {

            var today = await _dateTimeProvider.GetTodayDateTime();

            var specResult = TeacherAddUpdateSpec.IsSatisfiedBy(teacherAddUpdateModel, 18, today);

            if (specResult.OverallResult)
            {
                using (var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    var teacher = _mapper.Map(teacherAddUpdateModel, new Teacher());

                    await _asyncTeacherRepository.Update(teacher);

                    await _asyncTeacherRepository.Save();

                    scope.Complete();

                    return Results.WithOkSpec(true).AddMessage(Resource.Successful);
                }
            }
            else
            {
                return Results.WithFailSpec(false).AddSpec(specResult).AddMessage(Resource.Unsuccessfull);
            }
        }




        public async Task<Result<TeacherListModel>> GetList(TeacherFilterModel teacherFilterModel)
        {
            Expression<Func<Teacher, bool>> predicateData = teacher =>
                teacher.FirstName.Contains(teacherFilterModel.Firstname)
                || teacher.LastName.Contains(teacherFilterModel.Lastname)
                || teacher.BirthDate > teacherFilterModel.Birthdate
                || teacher.Gender == teacherFilterModel.Gender;

            var teachers = await _asyncTeacherRepository.GetWhere(predicateData);

            var teachersBl = _mapper.Map(teachers, new List<TeacherBlDto>());

            var teacherListModel = new TeacherListModel { Teachers = new List<TeacherBlDto>() };

            if (teachersBl.Count <= 0)
            {
                return Results.WithFail(teacherListModel).AddMessage(Resource.Unsuccessfull);
            }

            teacherListModel.Teachers = teachersBl;
            return Results.WithOk(teacherListModel).AddMessage(Resource.Successful);
        }

        public async Task<Result<string>> GetCachedData()
        {
            // LazyCache cache aside pattern için kullanılmıştı
            var now = await _cache.GetOrAddAsync("Test", () => _dateTimeProvider.GetTodayDateTime(),
                                                    new TimeSpan(0, 0, 5));



            var result = Results.WithOk(now.TimeOfDay.ToString());

            return result;
        }



    }
}
