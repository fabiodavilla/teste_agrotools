using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TesteAgrotools.Entities;
using TesteAgrotools.Infrastructure.Model;

namespace TesteAgrotools.Persistance
{
    public class AnswerRepository
    {
        private ProjectModel _context;

        public AnswerRepository(ProjectModel context)
        {
            _context = context;
        }

        public List<Answer> GetAll()
        {
            return _context.Answers.ToList();
        }

        public Answer GetById(int id)
        {
            return _context.Answers.Find(id);
        }

        public void Insert(Answer obj)
        {
            _context.Answers.Add(obj);
        }

        public void Update(Answer obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Answer existing = GetById(id);
            _context.Answers.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
