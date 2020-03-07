using System;
using System.Linq.Expressions;
using AutoMapper;
using SMS.BL.Domain.Student;
using SMS.BL.Domain.Teacher;
using SMS.DAL.Entities;


namespace SMS.BL.Infra
{
    public class BlMappingProfile : Profile
    {
        public BlMappingProfile()
        {
            CreateMap<TeacherBlDto, Teacher>(MemberList.None).ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Student, StudentBlDto>(MemberList.None).ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();



            // CreateMap<List<StudentBlDto>, List<Student>>(MemberList.None).ReverseMap();
        }
    }
}
