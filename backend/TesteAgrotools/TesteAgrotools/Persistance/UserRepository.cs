using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TesteAgrotools.Entities;
using TesteAgrotools.Infrastructure.Model;

namespace TesteAgrotools.Persistance
{
    public class UserRepository
    {
        private ProjectModel _context;

        public UserRepository(ProjectModel context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Insert(User obj)
        {
            _context.Users.Add(obj);
        }

        public void Update(User obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User existing = GetById(id);
            _context.Users.Remove(existing);
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
