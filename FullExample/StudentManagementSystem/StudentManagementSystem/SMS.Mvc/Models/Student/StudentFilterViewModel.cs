using System;
using System.Collections.Generic;
using SMS.BL.Domain;
using SMS.Core.Entities;

namespace SMS.Mvc.Models.Student
{
   public class StudentFilterViewModel: BaseMvcViewModel
   {


       public string Firstname => string.Empty;
       public string Lastname => string.Empty;
       public DateTime Birthdate => DateTime.MinValue;
       public string Gender => String.Empty;

       public List<Option<int, string>> Genders { get; set; }



        public int Age => 0;

   }
}
