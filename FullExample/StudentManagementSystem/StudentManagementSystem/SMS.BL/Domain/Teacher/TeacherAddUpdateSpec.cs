using System;
using FluentSpecification;
using FluentSpecification.Abstractions.Validation;
using FluentSpecification.Core;


namespace SMS.BL.Domain.Teacher
{
    public static class TeacherAddUpdateSpec
    {

        public static SpecificationResult IsSatisfiedBy(TeacherAddUpdateModel teacherAddUpdateModel, int minAge, DateTime today)
        {
            var spec = FluentSpecification.Specification.NotNull<TeacherAddUpdateModel>()
                .And().NotEmpty(t => t.Teacher.FirstName).And().MinLength(t=>t.Teacher.FirstName, 3)
                .And().NotEmpty(t => t.Teacher.LastName).And().MinLength(t => t.Teacher.LastName, 3)
                .And().Expression(t=>t.Teacher.Gender, s => s!="-1")
                .And().Expression(t=> t.Teacher.BirthDate, t=> t.AddYears(minAge).Date <= today.Date);

            spec.IsSatisfiedBy(teacherAddUpdateModel, out var specificationResult);
            return specificationResult;
        }

    }
}
