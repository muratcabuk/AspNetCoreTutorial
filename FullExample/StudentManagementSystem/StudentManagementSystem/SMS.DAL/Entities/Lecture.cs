using System.Collections.Generic;
using SMS.Core.Data;

namespace SMS.DAL.Entities
{
    public class Lecture: BaseDataEntity
    {
        public  string Name { get; set; }
        public  string Description { get; set; }
        public List<Course> Courses { get; set; }


    }
}
