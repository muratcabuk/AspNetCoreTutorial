using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Options;
using SMS.Core.Entities;

namespace SMS.Mvc.Models.Teacher
{
    public class TeacherAddUpdateViewModel : BaseMvcViewModel
    {

        public TeacherMvcDto Teacher { get; set; }
        public string Message { get; set; }
        public List<Option<int, String>> Genders { get; set; }



    }
}
