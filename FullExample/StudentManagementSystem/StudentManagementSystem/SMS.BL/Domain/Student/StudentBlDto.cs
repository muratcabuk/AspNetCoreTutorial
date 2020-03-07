using System;

namespace SMS.BL.Domain.Student
{
    public  class StudentBlDto: BaseBlDto
    {
        public  int Id { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudentId { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

    }
}
