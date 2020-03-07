using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.BL.Domain.Teacher
{
   public class TeacherFilterModel: BaseBlModel
   {
       public string Firstname => string.Empty;
       public string Lastname => string.Empty;
       public DateTime Birthdate => DateTime.MinValue;
       public string Gender => string.Empty;
       public int Age => 18;
   }
}
