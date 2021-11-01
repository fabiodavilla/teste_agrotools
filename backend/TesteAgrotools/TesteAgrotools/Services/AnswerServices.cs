using System;
using System.Collections.Generic;
using System.Linq;
using TesteAgrotools.DTO;
using TesteAgrotools.Entities;
using TesteAgrotools.Persistance;

namespace TesteAgrotools.Services
{
    public class AnswerServices
    {
        private AnswerRepository _repository;
        private UserServices _userServices;
        private FormRepository _formRepository;
        private FormFieldRepository _formFieldRepository;

        public AnswerServices(
            AnswerRepository repository,
            UserServices userServices,
            FormRepository formRepository,
            FormFieldRepository formFieldRepository
        )
        {
            _repository = repository;
            _userServices = userServices;
            _formRepository = formRepository;
            _formFieldRepository = formFieldRepository;
        }

        public List<Answer> GetAnswerByIdForm(int idForm)
        {
            try
            {
                var queryAnswer = _repository.GetAll();
                var queryForm = _formRepository.GetAll();
                var queryField = _formFieldRepository.GetAll();
                var queryUser = _userServices.GetAll();

                List<Answer> queryResult = (
                    from answer in queryAnswer
                    join formField in queryField on answer.FormFieldFK equals formField.ID
                    join form in queryForm on formField.FormFK equals form.ID
                    join user in queryUser on answer.UserFK equals user.ID
                    where form.ID == idForm
                    select answer
                ).ToList();

                return queryResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Create(FormAnswerDTO form)
        {
            try
            {
                User user = _userServices.GetUserByName(form.User);

                foreach (AnswerDTO answerForm in form.Answers)
                {
                    Answer answer = new Answer
                    {
                        UserFK = user.ID,
                        UserAnswer = answerForm.Answer,
                        FormFieldFK = answerForm.IdQuestion,
                        latitude = form.latitude,
                        longitude = form.longitude
                    };

                    _repository.Insert(answer);
                }

                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
