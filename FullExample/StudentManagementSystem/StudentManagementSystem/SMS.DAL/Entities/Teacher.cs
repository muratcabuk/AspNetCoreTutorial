using System;
using System.Collections.Generic;
using SMS.Core.Data;

namespace SMS.DAL.Entities
{
    public class Teacher : BaseDataEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public List<Course> Courses { get; set; }
    }
}
