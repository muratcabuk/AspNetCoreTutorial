using System;
using System.Collections.Generic;
using System.Text;
using SMS.BL.Models;
using SMS.Core.Interfaces;
using SMS.Core.Specification;

namespace SMS.BL.Specifications
{
   public class StudentAddUpdateSpecification :  CompositeSpecification<StudentAddUpdateModel>
   {

       private readonly DateTime _dt;
        public StudentAddUpdateSpecification(DateTime dt)
        {
            _dt = dt;
        }

        public override bool IsSatisfiedBy(StudentAddUpdateModel o)
        {

            var a = new ExpressionSpecification<StudentAddUpdateModel>(s =>s.FirstName.Length > 0 && s.LastName.Length > 0)
                                    .And(new ExpressionSpecification<StudentAddUpdateModel>(s => s.BirthDate > _dt));

            return a.IsSatisfiedBy(o);
        }
    }
}
