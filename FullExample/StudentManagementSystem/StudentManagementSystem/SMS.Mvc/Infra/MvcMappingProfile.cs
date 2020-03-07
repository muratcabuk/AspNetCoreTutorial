using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using SMS.BL.Domain.Student;
using SMS.BL.Domain.Teacher;
using SMS.Mvc.Models.Student;
using SMS.Mvc.Models.Teacher;

namespace SMS.Mvc.Infra
{
    public class MvcMappingProfile : Profile
    {

        public MvcMappingProfile()
        {
            CreateMap<TeacherBlDto, TeacherMvcDto>(MemberList.None).ReverseMap();
           
            CreateMap<StudentBlDto, StudentMvcDto>(MemberList.None).ReverseMap();

            CreateMap<StudentFilterViewModel, StudentFilterModel>(MemberList.None);

            CreateMap<TeacherFilterViewModel, TeacherFilterModel>(MemberList.None);


        }


    }
}
