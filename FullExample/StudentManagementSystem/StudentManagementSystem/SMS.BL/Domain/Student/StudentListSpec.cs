using System;
using System.Linq.Expressions;
using FluentSpecification.Abstractions.Validation;
using Specification = FluentSpecification.Specification;

namespace SMS.BL.Domain.Student
{
    public static class StudentListSpec
    {
        public static SpecificationResult IsSatisfiedBy(StudentListModel studentAddUpdateModel, Expression<Func<StudentBlDto, bool>> predicate)
        {
            var spec = Specification.NotNull<Expression<Func<StudentBlDto, bool>>>();

            spec.IsSatisfiedBy(predicate, out var specificationResult);

            return specificationResult;
        }
    }
}
