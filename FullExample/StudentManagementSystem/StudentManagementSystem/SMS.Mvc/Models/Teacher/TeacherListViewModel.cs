using System.Collections.Generic;
using SMS.Mvc.Models.Student;

namespace SMS.Mvc.Models.Teacher
{
    public class TeacherListViewModel : BaseMvcViewModel
    {
       public IList<TeacherMvcDto> Teachers { get; set; }
       public string ReturnMessage { get; set; }

       public string TimeText { get; set; }
       
    }
}
