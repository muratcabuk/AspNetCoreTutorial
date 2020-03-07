using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Maps
{
   internal class CourseMap
    {
       internal CourseMap(EntityTypeBuilder<Course> entityBuilder)
        {
            entityBuilder.HasKey(course=> course.Id);



            entityBuilder
                .HasOne(course => course.Lecture)
                .WithMany(lecture => lecture.Courses)
                .HasForeignKey(course => course.LectureId);

            entityBuilder
                .HasOne(course => course.Semester)
                .WithMany(semester => semester.Courses)
                .HasForeignKey(course => course.SemesterId);


            entityBuilder
                .HasOne(course => course.Semester)
                .WithMany(teacher => teacher.Courses)
                .HasForeignKey(teacher => teacher.TeacherId);





            entityBuilder.ToTable("Course");


        }
    }
}
