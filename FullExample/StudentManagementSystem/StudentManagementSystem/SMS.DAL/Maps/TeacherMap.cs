using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Maps
{
    internal class TeacherMap
    {

        internal TeacherMap(EntityTypeBuilder<Teacher> entityBuilder)
        {


            entityBuilder
                .HasKey(teacher => teacher.Id);


            entityBuilder.ToTable("Teacher");


        }
    }
}