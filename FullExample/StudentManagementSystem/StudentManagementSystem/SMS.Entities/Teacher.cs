using System;
using System.Collections.Generic;

namespace SMS.Entities
{
   public class Teacher : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }

        public IList<Course> Courses { get; set; }


    }
}
