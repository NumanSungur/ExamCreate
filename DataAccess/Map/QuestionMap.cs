using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Map
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Content).IsRequired();

            builder.HasOne<Exam>(x => x.Exam).WithMany(x => x.Questions).HasForeignKey(x => x.ExamID);
            builder.ToTable("Questions");
        }
    }
}
