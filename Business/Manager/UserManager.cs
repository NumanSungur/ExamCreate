using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Manager
{
    public class UserManager 
    {
        UnitOfWork work;
        public UserManager(UnitOfWork _work)
        {
            work = _work;
        }
        public bool Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) && string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("Lütfen Kullanıcı Adı ve Şifre giriniz");
            }
            work.UserRepository.Add(user);
            return work.ApplyChanges();
        }
        public User Login(User user)
        {
            User _user = work.UserRepository.GetAll().Where(x => x.UserName == user.UserName && x.Password == user.Password).SingleOrDefault();
            return _user;
        }
    }
}
