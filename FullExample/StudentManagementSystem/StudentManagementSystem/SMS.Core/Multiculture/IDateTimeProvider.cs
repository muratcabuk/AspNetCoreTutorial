using System;
using System.Threading.Tasks;

namespace SMS.Core.Multiculture
{
    public interface IDateTimeProvider
    {

        Task<DateTime> GetTodayDateTime();

        Task<int> GetElapsedYears(DateTime startDateTime, DateTime endDateTime);

        Task<int> GetElapsedYearsFromNow(DateTime startDateTime);

    }
}
