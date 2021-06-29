using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class BaseRepository<TEntity> where TEntity : class,new()
    {
        protected ExamContext context;
        public BaseRepository(ExamContext _context)
        {
            context = _context;
        }
        public void Add(TEntity item)
        {
            context.Set<TEntity>().Add(item);
        }
        public void Delete(TEntity item)
        {
            context.Set<TEntity>().Remove(item);
        }
        public void Update(TEntity item)
        {
            context.Set<TEntity>().Update(item);
        }
        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }
    }
}
