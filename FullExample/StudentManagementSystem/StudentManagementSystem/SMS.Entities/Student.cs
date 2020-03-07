using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
    public  class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Char Gender { get; set; }

    }
}
