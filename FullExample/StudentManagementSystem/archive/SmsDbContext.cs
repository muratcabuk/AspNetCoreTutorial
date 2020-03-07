using Microsoft.EntityFrameworkCore;
using SMS.Core.Data;
using SMS.Core.Data.Interfaces;
using SMS.DAL.Entities;

namespace SMS.DAL
{
    public class SmsDbContext : BaseDbContext, IDbContext
    {



        public SmsDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasKey(student => student.Id);


            modelBuilder.Entity<Lecture>()
                .HasKey(lecture => lecture.Id);


            modelBuilder.Entity<Teacher>()
                .HasKey(teacher => teacher.Id);



            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment => enrollment.Id);

            modelBuilder.Entity<Course>()
                .HasKey(semesterLectureLine => semesterLectureLine.Id);


            modelBuilder.Entity<Course>()
                .HasOne(semesterLectureLine => semesterLectureLine.Lecture)
                .WithMany(lecture=>lecture.Courses)
                .HasForeignKey(semesterLectureLine => semesterLectureLine.LectureId);

            modelBuilder.Entity<Course>()
                .HasOne(semesterLectureLine => semesterLectureLine.Semester)
                .WithMany(semester => semester.Courses)
                .HasForeignKey(semesterLectureLine => semesterLectureLine.SemesterId);


            modelBuilder.Entity<Course>()
                .HasOne(semesterLectureLine => semesterLectureLine.Semester)
                .WithMany(teacher => teacher.Courses)
                .HasForeignKey(teacher => teacher.TeacherId);



            modelBuilder.Entity<Lecture>().ToTable("Lecture");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Semester>().ToTable("Semester");
            
            
            //many to many
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");






        }




    }
}
