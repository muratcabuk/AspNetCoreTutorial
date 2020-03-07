using System.Collections.Generic;
using SMS.Mvc.Models.Student;

namespace SMS.Mvc.Models.Student
{
    public class StudentListViewModel : BaseMvcViewModel
    {
       public List<StudentMvcDto> Students { get; set; }
       public string ReturnMessage { get; set; }

       public string TimeText { get; set; }
       
    }
}
