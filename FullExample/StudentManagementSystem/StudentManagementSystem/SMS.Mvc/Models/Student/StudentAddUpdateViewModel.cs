using System;
using System.Collections.Generic;
using SMS.Core.Entities;

namespace SMS.Mvc.Models.Student
{
    public class StudentAddUpdateViewModel : BaseMvcViewModel
    {
        public  StudentMvcDto Student { get; set; }
        public List<Option<int, string>> Genders { get; set; }
        public  string Message { get; set; }
    }
}
