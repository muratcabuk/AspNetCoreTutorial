using System;
using FluentSpecification;
using FluentSpecification.Abstractions.Validation;
using FluentSpecification.Core;


namespace SMS.BL.Domain.Student
{
    public static class StudentAddUpdateSpec
    {

        public static SpecificationResult IsSatisfiedBy(StudentAddUpdateModel studentAddUpdateModel, int minAge, DateTime today)
        {
            int result;
            var spec = FluentSpecification.Specification.NotNull<StudentAddUpdateModel>()
                .And().NotEmpty(t => t.Student.FirstName).And().MinLength(t=>t.Student.FirstName, 3)
                .And().NotEmpty(t => t.Student.LastName).And().MinLength(t => t.Student.LastName, 3)
                .And().Expression(t=>t.Student.Gender, s => s!="-1")
                .And().MinLength(t=>t.Student.StudentId, 5).And().Expression(t=>t.Student.StudentId, s => int.TryParse(s,out result))
                .And().Expression(t=>t.Student.Age, t=> t >= minAge )
                .And().Expression(t=> t.Student.BirthDate, t=> t.AddYears(minAge).Date <= today.Date);

            spec.IsSatisfiedBy(studentAddUpdateModel, out var specificationResult);
            return specificationResult;
        }

    }
}
