using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ExamContext context) : base(context)
        {

        }
    }
}
