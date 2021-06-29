using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class AnswerRepository : BaseRepository<Answer>
    {
        public AnswerRepository(ExamContext context) : base(context)
        {

        }
    }
}
