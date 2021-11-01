using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteAgrotools.Entities;
using TesteAgrotools.Infrastructure.Model;

namespace TesteAgrotools.Persistance
{
    public class FormFieldRepository : IDisposable
    {
        private ProjectModel _context;

        public FormFieldRepository(ProjectModel context)
        {
            _context = context;
        }

        public List<FormField> GetAll()
        {
            return _context.FormFields.ToList();
        }

        public FormField GetById(int id)
        {
            return _context.FormFields.Find(id);
        }

        public void Insert(FormField obj)
        {
            _context.FormFields.Add(obj);
        }

        public void Update(FormField obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            FormField existing = GetById(id);
            _context.FormFields.Remove(existing);
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
