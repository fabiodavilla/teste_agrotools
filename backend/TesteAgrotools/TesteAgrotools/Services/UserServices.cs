using System;
using System.Collections.Generic;
using System.Linq;
using TesteAgrotools.Entities;
using TesteAgrotools.Persistance;

namespace TesteAgrotools.Services
{
    public class UserServices
    {
        private UserRepository _repository;

        public UserServices(UserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetAll()
        {
            List<User> users = _repository.GetAll();

            return users;
        }

        public User GetUserByName(string username)
        {
            try
            {
                User user = _repository.GetAll()
                    .Where(x => x.UserName.Equals(username))
                    .FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Login(User userSearch)
        {
            try
            {
                User user = GetUserByName(userSearch.UserName);

                if (user != null && user.Password.Equals(userSearch.Password))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
