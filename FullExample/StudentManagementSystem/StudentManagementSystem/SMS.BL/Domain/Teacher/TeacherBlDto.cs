using System;

namespace SMS.BL.Domain.Teacher
{
    public class TeacherBlDto : BaseBlDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }


    }
}
