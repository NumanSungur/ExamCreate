using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class QuestionRepository : BaseRepository<Question>
    {
        public QuestionRepository(ExamContext context) : base(context)
        {

        }
    }
}
