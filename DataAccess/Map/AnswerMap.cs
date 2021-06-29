using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Map
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Content).IsRequired();

            builder.HasOne<Question>(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x => x.QuestionID);
            builder.ToTable("Answers");
        }
    }
}
