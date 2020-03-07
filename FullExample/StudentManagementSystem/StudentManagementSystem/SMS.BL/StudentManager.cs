using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using SMS.BL.Domain;
using SMS.BL.Domain.Student;
using SMS.Core.Data.Interfaces;
using SMS.Core.Interfaces;
using SMS.Core.Result;
using SMS.DAL.Entities;
using SMS.Globalizaiton.Resources;
using LazyCache;
using SMS.Core.Multiculture;

namespace SMS.BL
{
    public class StudentManager : BaseManagement, IStudentManager
    {

        private readonly IAsyncRepository<Student> _asyncStudentRepository;
        private readonly IMapper _mapper;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IAppCache _cache;

        public StudentManager(IAsyncRepository<Student> asyncStudentRepository,
                                    IMapper mapper,
                                    IDateTimeProvider dateTimeProvider,
                                    IAppCache cache)
        {
            _asyncStudentRepository = asyncStudentRepository;
            _mapper = mapper;
            _dateTimeProvider = dateTimeProvider;
            _cache = cache;
        }

        public async Task<ResultSpec<int>> Add(StudentAddUpdateModel studentAddUpgdateModel)
        {
            var today = await _dateTimeProvider.GetTodayDateTime();
            var specResult = StudentAddUpdateSpec.IsSatisfiedBy(studentAddUpgdateModel, 18, today);

            if (specResult.OverallResult)
            {
                using (var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    var student = _mapper.Map<Student>(studentAddUpgdateModel.Student);

                    var newStudentId = await _asyncStudentRepository.Insert(student);

                    await _asyncStudentRepository.Save();

                    scope.Complete();

                    return Results.WithOkSpec<int>(newStudentId).AddMessage(Resource.Successful).AddSpec(specResult);
                }
            }
            else
            {
                return Results.WithFailSpec<int>(-1).AddSpec(specResult);
            }
        }

        public async Task<ResultSpec<bool>> Update(StudentAddUpdateModel studentAddUpdateModel)
        {

            var today = await _dateTimeProvider.GetTodayDateTime();
            var specResult = StudentAddUpdateSpec.IsSatisfiedBy(studentAddUpdateModel, 18, today);

            if (specResult.OverallResult)
            {
                using (var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    var student = _mapper.Map(studentAddUpdateModel, new Student());

                    await _asyncStudentRepository.Update(student);

                    await _asyncStudentRepository.Save();

                    scope.Complete();

                    return Results.WithOkSpec(true).AddMessage(Resource.Successful);
                }
            }
            else
            {
                return Results.WithFailSpec(false).AddSpec(specResult).AddMessage(Resource.Unsuccessfull);
            }
        }

        public async Task<Result<StudentListModel>> GetList(StudentFilterModel studentFilterModel)
        {

            Expression<Func<Student, bool>> predicateData = student =>
                                    student.FirstName.Contains(studentFilterModel.Firstname)
                                    || student.LastName.Contains(studentFilterModel.Lastname)
                                    || student.BirthDate > studentFilterModel.Birthdate
                                    || student.Gender == studentFilterModel.Gender;


            var students = await _asyncStudentRepository.GetWhere(predicateData);

            var studentsBl = _mapper.Map(students, new List<StudentBlDto>());

            var studentListModel = new StudentListModel { Students = new List<StudentBlDto>() };

            if (studentsBl.Count <= 0)
            {
                return Results.WithFail(studentListModel).AddMessage(Resource.Unsuccessfull);
            }
            studentListModel.Students = studentsBl;
            return Results.WithOk(studentListModel).AddMessage(Resource.Successful);
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


