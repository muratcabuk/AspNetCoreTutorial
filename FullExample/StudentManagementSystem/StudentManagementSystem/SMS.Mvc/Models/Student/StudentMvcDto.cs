using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Mvc.Models.Student
{
    public class StudentMvcDto: BaseMvcDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudentId { get; set; }
        public Char Gender { get; set; }
        public int Age { get; set; }
    }
}
