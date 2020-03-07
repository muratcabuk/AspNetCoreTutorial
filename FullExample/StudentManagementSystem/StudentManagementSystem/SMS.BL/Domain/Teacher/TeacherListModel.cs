using System.Collections.Generic;

namespace SMS.BL.Domain.Teacher
{
    public class TeacherListModel : BaseBlModel
    {
        private IList<TeacherBlDto> teachers;

        public IList<TeacherBlDto> Teachers { get => teachers??new List<TeacherBlDto>(); set => teachers = value; }
    }
}
