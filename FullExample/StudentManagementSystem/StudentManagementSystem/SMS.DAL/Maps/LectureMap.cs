using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Maps
{
   internal class LectureMap
    {

        internal LectureMap(EntityTypeBuilder<Lecture> entityBuilder)
        {


            entityBuilder
                .HasKey(lecture => lecture.Id);


            entityBuilder.ToTable("Lecture");


        }
    }
}
