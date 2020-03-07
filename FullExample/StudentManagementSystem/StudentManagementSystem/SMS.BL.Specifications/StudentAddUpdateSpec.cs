using System;
using FluentSpecification;
using FluentSpecification.Abstractions.Validation;
using FluentSpecification.Core;
using SMS.BL.Models;
using Specification = FluentSpecification.Specification;

namespace SMS.BL.Specifications
{
    public static class StudentAddUpdateSpec
    {

        public static SpecificationResult IsSatisfiedBy(StudentAddUpdateModel studentAddUpdateModel, int minAge, DateTime today)
        {

            var dt = new DateTime(today.Year - minAge, today.Month, today.Day);

            var spec = Specification.NotNull<StudentAddUpdateModel>()
                .And().NotEmpty(t => t.Student.FirstName)
                .And().NotEmpty(t => t.Student.LastName)
                .And().True(t => t.Student.Age > minAge)
                .And().True(t=> t.Student.BirthDate.AddYears(minAge).Date >= today.Date);


            var specificationResult = new SpecificationResult();

            spec.IsSatisfiedBy(studentAddUpdateModel, out specificationResult);

            return specificationResult;
        }




    }
}
