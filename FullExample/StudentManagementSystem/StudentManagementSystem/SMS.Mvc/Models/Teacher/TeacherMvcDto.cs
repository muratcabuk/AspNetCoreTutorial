using System;
using System.Collections.Generic;

namespace SMS.Mvc.Models.Teacher
{
    public class TeacherMvcDto : BaseMvcDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }



    }
}
