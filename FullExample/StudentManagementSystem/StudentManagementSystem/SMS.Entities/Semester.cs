using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
   public class Semester: BaseEntity
    {
        public int Year { get; set; }
        public string Term { get; set; }

        public IList<Course> Courses { get; set; }

    }
}
