using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class ExamRepository : BaseRepository<Exam>
    {
        public ExamRepository(ExamContext context) : base(context)
        {

        }
    }
}
