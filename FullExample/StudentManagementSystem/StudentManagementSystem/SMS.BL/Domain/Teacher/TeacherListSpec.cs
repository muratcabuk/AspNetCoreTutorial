using System;
using System.Linq.Expressions;
using FluentSpecification.Abstractions.Validation;
using Specification = FluentSpecification.Specification;

namespace SMS.BL.Domain.Teacher
{
    public static class TeacherListSpec
    {
        public static SpecificationResult IsSatisfiedBy(TeacherListModel studentAddUpdateModel, Expression<Func<TeacherBlDto, bool>> predicate)
        {
            var spec = Specification.NotNull<Expression<Func<TeacherBlDto, bool>>>();

            spec.IsSatisfiedBy(predicate, out var specificationResult);

            return specificationResult;
        }
    }
}
