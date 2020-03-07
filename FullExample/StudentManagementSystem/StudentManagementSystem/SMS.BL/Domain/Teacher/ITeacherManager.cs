using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SMS.Core.Interfaces;
using SMS.Core.Result;


namespace SMS.BL.Domain.Teacher
{
    public interface ITeacherManager: IManager
    {
        Task<ResultSpec<int>> Add(TeacherAddUpdateModel studentAddUpdateModel);
        Task<ResultSpec<bool>> Update(TeacherAddUpdateModel studentAddUpdateModel);
        Task<Result<TeacherListModel>> GetList(TeacherFilterModel tacherFilterModel);
        Task<Result<String>> GetCachedData();
    }
}