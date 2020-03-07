using SMS.Core.Data;

namespace SMS.DAL.Entities
{
    public class Course: BaseDataEntity
    {

        public int LectureId { get; set; }
        public  int SemesterId { get; set; }

        public int TeacherId { get; set; }

        public Lecture Lecture { get; set; }
        public Semester Semester { get; set; }
        public  Teacher Teacher { get; set; }



    }
}
