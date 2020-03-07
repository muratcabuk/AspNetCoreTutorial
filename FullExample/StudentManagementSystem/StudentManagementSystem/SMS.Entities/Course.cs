using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Entities
{
   public class Course: BaseEntity
    {

        public int LectureId { get; set; }
        public  int SemesterId { get; set; }

        public int TeacherId { get; set; }

        public Lecture Lecture { get; set; }
        public Semester Semester { get; set; }
        public  Teacher Teacher { get; set; }



    }
}
