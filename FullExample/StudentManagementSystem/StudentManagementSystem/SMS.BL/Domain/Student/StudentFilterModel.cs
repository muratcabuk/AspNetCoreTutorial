using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.BL.Domain.Student
{
    public class StudentFilterModel : BaseBlModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
