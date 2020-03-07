using System;
using System.Collections.Generic;
using SMS.BL.Domain;
using SMS.Core.Entities;

namespace SMS.Mvc.Models.Teacher
{
    public class TeacherFilterViewModel : BaseMvcViewModel
    { 
        public string Firstname { get; set; }
    
    public string Lastname { get; set; }
    public DateTime Birthdate { get; set; }
    public string Gender { get; set; }

    public List<Option<int, string>> Genders { get; set; }

}
}
