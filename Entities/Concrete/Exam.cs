﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Exam
    {
        public Exam()
        {
            Questions = new List<Question>();
            

        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}
