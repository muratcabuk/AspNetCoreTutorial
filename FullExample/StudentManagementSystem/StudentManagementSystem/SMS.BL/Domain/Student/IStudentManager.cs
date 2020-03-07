using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SMS.Core.Interfaces;
using SMS.Core.Result;

namespace SMS.BL.Domain.Student
{
    public interface IStudentManager:IManager
    {
        Task<ResultSpec<int>> Add(StudentAddUpdateModel studentAddUpdateModel);
        Task<ResultSpec<bool>> Update(StudentAddUpdateModel studentAddUpdateModel);
        Task<Result<StudentListModel>> GetList(StudentFilterModel studentFilterModel);
        Task<Result<String>> GetCachedData();
    }
}