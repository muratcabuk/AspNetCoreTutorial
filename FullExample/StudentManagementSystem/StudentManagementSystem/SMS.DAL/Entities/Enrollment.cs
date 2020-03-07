using SMS.Core.Data;

namespace SMS.DAL.Entities
{
    public class Enrollment: BaseDataEntity
    {

        public int StudentId { get; set; }
        public Student Student { get; set; }
        
        public int CourseId { get; set; }

        public Course Course { get; set; }

        }


    
}
