using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Manager
{
    public class ExamManager 
    {
        private readonly UnitOfWork work;
        public ExamManager(UnitOfWork _work)
        {
            work = _work;
        }
        public bool SaveExam(Exam exam)
        {
            if (string.IsNullOrWhiteSpace(exam.Article.Title) && string.IsNullOrWhiteSpace(exam.Article.Content))
            {
                throw new Exception("Article boş gönderilemez");
            }
            if (exam.Questions.Count != 4)
            {

                throw new Exception("Lütfen 4 tane soru giriniz");
            }
            foreach (var item in exam.Questions)
            {
                if (string.IsNullOrWhiteSpace(item.Content))
                {
                    throw new Exception("Lütfen soruları yazınız");

                }
                if (item.Answers.Count != 4)
                {
                    throw new Exception("Lütfen soruların cevaplarını eksiksiz giriniz");
                }
                foreach (var answer in item.Answers)
                {
                    if (string.IsNullOrWhiteSpace(answer.Content))
                    {
                        throw new Exception("Lütfen CEVAP ALANLARINI BOŞ BIRAKMAYIN");
                    }
                }
            }
            try
            {
                work.ArticleRepository.Add(exam.Article);

                exam.CreatedDate = DateTime.Now;
                exam.ArticleID = exam.Article.ID;
                work.ExamRepository.Add(exam);
                foreach (var item in exam.Questions)
                {
                    item.ExamID = exam.ID;
                    work.QuestionRepository.Add(item);
                    foreach (var answer in item.Answers)
                    {
                        answer.QuestionID = item.ID;
                        work.AnswerRepository.Add(answer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return work.ApplyChanges();
        }
        public List<Exam> GetList()
        {
            return work.ExamRepository.GetAll();
        }
        public bool Delete(int id)
        {
            Exam exam = work.ExamRepository.Get(id);
            if (exam != null)
            {
                work.ExamRepository.Delete(exam);
            }
            return work.ApplyChanges();
        }
        public Exam Get(int id)
        {
            var exam = work.ExamRepository.Get(id);
            if (exam != null)
            {
                return new Exam();
            }
            else
            {
                return exam;
            }
             
            
        }
        public Article GetArticle(int id)
        {           
            return work.ArticleRepository.Get(id);
        }
        public Answer GetAnswer(int id)
        {
            return work.AnswerRepository.Get(id);
        }
    }
}
