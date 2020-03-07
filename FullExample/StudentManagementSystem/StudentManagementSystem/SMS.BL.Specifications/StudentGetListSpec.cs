using System;
using System.Linq.Expressions;
using System.Reflection;
using FluentSpecification;
using FluentSpecification.Abstractions.Validation;
using FluentSpecification.Core;
using SMS.BL.Models;
using Specification = FluentSpecification.Specification;

namespace SMS.BL.Specifications
{
    public static class StudentGetListSpec
    {

        public static SpecificationResult IsSatisfiedBy(StudentListModel studentAddUpdateModel, Expression<Func<StudentBl, bool>> predicate)
        {

            var spec = Specification.NotNull<Expression<Func<StudentBl, bool>>>();

            var specificationResult = new SpecificationResult();

            spec.IsSatisfiedBy(predicate, out specificationResult);

            return specificationResult;
        }




    }
}
