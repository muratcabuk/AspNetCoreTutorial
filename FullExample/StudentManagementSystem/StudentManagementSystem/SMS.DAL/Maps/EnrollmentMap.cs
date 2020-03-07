using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Maps
{
   internal class EnrollmentMap
    {

        internal EnrollmentMap(EntityTypeBuilder<Enrollment> entityBuilder)
        {


            entityBuilder
                .HasKey(enrollment => enrollment.Id);

            entityBuilder
                .HasOne(student => student.Student)
                .WithMany(student => student.Enrollments)
                .HasForeignKey(student => student.StudentId);



            entityBuilder.ToTable("Enrollment");


        }



    }
}
