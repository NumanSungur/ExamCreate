using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Map
{
    public class ExamMap : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasOne<Article>(x => x.Article).WithMany(c => c.Exams).HasForeignKey(a => a.ArticleID);
            builder.ToTable("Exams");
        }
    }
}
