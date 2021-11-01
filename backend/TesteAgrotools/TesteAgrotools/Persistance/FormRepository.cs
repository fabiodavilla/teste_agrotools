using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteAgrotools.Entities;
using TesteAgrotools.Infrastructure.Model;

namespace TesteAgrotools.Persistance
{
    public class FormRepository : IDisposable
    {
        private ProjectModel _context;

        public FormRepository(ProjectModel context)
        {
            _context = context;
        }

        public List<Form> GetAll()
        {
            return _context.Forms.ToList();
        }

        public Form GetById(int id)
        {
            return _context.Forms.Find(id);
        }

        public void Insert(Form obj)
        {
            _context.Forms.Add(obj);
        }

        public void Update(Form obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Form existing = GetById(id);
            _context.Forms.Remove(existing);
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
