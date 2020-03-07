using System;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Data;
using SMS.Core.Data.Interfaces;
using SMS.DAL.Entities;
using SMS.DAL.Maps;

namespace SMS.DAL
{
   public class SmsDbContext:DbContext
    {

        public SmsDbContext(DbContextOptions<SmsDbContext> options) : base(options)
        {
        }

        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            
            base.OnModelCreating(modelBuilder);
            _ = new TeacherMap(modelBuilder.Entity<Teacher>());
            _ = new StudentMap(modelBuilder.Entity<Student>());
            _ = new LectureMap(modelBuilder.Entity<Lecture>());
            _ = new CourseMap(modelBuilder.Entity<Course>());
            _ = new EnrollmentMap(modelBuilder.Entity<Enrollment>());
            _ = new SemesterMap(modelBuilder.Entity<Semester>());

        }




    }
}
