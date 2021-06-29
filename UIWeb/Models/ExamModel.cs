using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ExamModel

    {
        public ExamModel()
        {
            Questions = new List<QuestionModel>();


        }
        public int ID { get; set; }
        public virtual List<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {

        public QuestionModel()
        {
            Answers = new List<AnswerModel>();


        }
        public string Content { get; set; }
        public virtual List<AnswerModel> Answers { get; set; }


    }
    public class ArticleModel
    {

        public ArticleModel()
        {
            Exams = new List<ExamModel>();


        }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual List<ExamModel> Exams { get; set; }


    }

    public class AnswerModel
    {
        public string Content { get; set; }
        public bool? IsRight { get; set; }

    }
}
