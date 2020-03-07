using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
    public class Lecture: BaseEntity
    {
        public  string Name { get; set; }
        public  string Description { get; set; }
        public IList<Course> Courses { get; set; }


    }
}
