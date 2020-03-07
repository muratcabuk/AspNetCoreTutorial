using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.DAL.Entities;

namespace SMS.DAL.Maps
{
  internal class SemesterMap
    {

        internal SemesterMap(EntityTypeBuilder<Semester> entityBuilder)
        {


            entityBuilder
                .HasKey(semester => semester.Id);


            entityBuilder.ToTable("Semester");


        }

    }
}
