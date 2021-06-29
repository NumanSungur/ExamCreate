using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(ExamContext context) : base(context)
        {

        }
    }
}
