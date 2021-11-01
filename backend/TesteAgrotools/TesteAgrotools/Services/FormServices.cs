using System;
using System.Collections.Generic;
using TesteAgrotools.DTO;
using TesteAgrotools.Entities;
using TesteAgrotools.Persistance;

namespace TesteAgrotools.Services
{
    public class FormServices
    {
        private FormRepository _repository;
        private FormFieldServices _formFieldServices;

        public FormServices(
            FormRepository repository,
            FormFieldServices formFieldServices
        )
        {
            _repository = repository;
            _formFieldServices = formFieldServices;
        }

        public List<Form> GetAll()
        {
            try
            {
                List<Form> result = _repository.GetAll();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Form GetById(int id)
        {
            try
            {
                Form form = _repository.GetById(id);
                List<FormField> formFiels = _formFieldServices.GetAllByIdForm(id);

                FullFormDTO data = new FullFormDTO
                {
                    ID = form.ID,
                    Title = form.Title,
                    User = form.User,
                    CreateDate = form.CreateDate,
                    fields = formFiels
                };

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Create(FullFormDTO form)
        {
            try
            {
                Form newform = new Form
                {
                    Title = form.Title,
                    User = form.User,
                    CreateDate = DateTime.Now
                };

                _repository.Insert(newform);
                _repository.Save();

                foreach (FormField field in form.fields)
                {
                    field.FormFK = newform.ID;

                    _formFieldServices.Create(field);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
