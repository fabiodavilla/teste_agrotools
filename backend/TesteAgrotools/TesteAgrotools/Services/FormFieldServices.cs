using System;
using System.Collections.Generic;
using System.Linq;
using TesteAgrotools.Entities;
using TesteAgrotools.Persistance;

namespace TesteAgrotools.Services
{
    public class FormFieldServices
    {
        private FormFieldRepository _repository;

        public FormFieldServices(FormFieldRepository repository)
        {
            _repository = repository;
        }

        public List<FormField> GetAllByIdForm(int idForm)
        {
            List<FormField> result = _repository.GetAll()
                .Where(x => x.FormFK.Equals(idForm))
                .ToList();

            return result;
        }

        public void Create(FormField formField)
        {
            try
            {
                _repository.Insert(formField);
                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
