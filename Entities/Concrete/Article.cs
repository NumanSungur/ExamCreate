using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Article
    {
        public Article()
        {
            Exams = new List<Exam>();


        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
