using System.Collections.Generic;

namespace SMS.BL.Domain.Student
{
    public class StudentListModel : BaseBlModel
    {
        private List<StudentBlDto> students;

        public List<StudentBlDto> Students { get => students??new List<StudentBlDto>(); set => students = value; }
    }
}
