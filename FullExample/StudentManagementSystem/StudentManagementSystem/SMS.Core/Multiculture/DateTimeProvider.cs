using System;
using System.Threading.Tasks;

namespace SMS.Core.Multiculture
{
  public  class DateTimeProvider:IDateTimeProvider
    {
        public async Task<DateTime> GetTodayDateTime()
        {
           // return await new Task<DateTime>(() => DateTime.Now);

            return await Task.Run(new Func<DateTime>(() => DateTime.Now));



        }

        public async Task<int> GetElapsedYears(DateTime startDateTime, DateTime endDateTime)
        {

            return await new Task<int>(() => (endDateTime.Year - startDateTime.Year - 1) +
                                             (((endDateTime.Month > startDateTime.Month) ||
                                               ((endDateTime.Month == startDateTime.Month) &&
                                                (endDateTime.Day >= startDateTime.Day)))
                                                 ? 1
                                                 : 0));





        }

        public async Task<int> GetElapsedYearsFromNow(DateTime startDateTime)
        {
            var endDateTime = await GetTodayDateTime();

            return await GetElapsedYears(startDateTime, endDateTime.Date);


        }

       

    }
}
