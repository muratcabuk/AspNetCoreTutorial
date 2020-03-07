using System.Collections.Generic;
using SMS.Core.Data;

namespace SMS.DAL.Entities
{
    public class Semester: BaseDataEntity
    {
        public int Year { get; set; }
        public string Term { get; set; }

        public List<Course> Courses { get; set; }

    }
}
