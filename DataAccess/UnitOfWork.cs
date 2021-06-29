using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UnitOfWork
    {
        private readonly ExamContext context;
        public UnitOfWork(ExamContext _context)
        {
            context = _context;
        }

        private UserRepository _userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(context);
                }
                return _userRepository;
            }
        }
        private ArticleRepository _articleRepository;
        public ArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(context);
                }
                return _articleRepository;
            }
        }
        private QuestionRepository _questionRepository;
        public QuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository == null)
                {
                    _questionRepository = new QuestionRepository(context);
                }
                return _questionRepository;
            }
        }

        private ExamRepository _examRepository;
        public ExamRepository ExamRepository
        {
            get
            {
                if (_examRepository == null)
                {
                    _examRepository = new ExamRepository(context);
                }
                return _examRepository;
            }
        }
        private AnswerRepository _answerRepository;
        public AnswerRepository AnswerRepository
        {
            get
            {
                if (_answerRepository == null)
                {
                    _answerRepository = new AnswerRepository(context);
                }
                return _answerRepository;
            }
        }        
        public bool ApplyChanges()
        {
            bool isSuccess = false;            
            var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                context.SaveChanges();
                transaction.Commit();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                isSuccess = false;
                throw new Exception(ex.Message);
            }
            finally
            {
                transaction.Dispose();
            }
            return isSuccess;
        }
    }
}
