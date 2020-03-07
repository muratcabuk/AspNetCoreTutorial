using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Maps
{
    internal class StudentMap
    {

        internal StudentMap(EntityTypeBuilder<Student> entityBuilder)
        {
            entityBuilder.HasKey(student => student.Id);

            entityBuilder.ToTable("Student");


        }

    }
}
