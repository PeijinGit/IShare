using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class User : IUserBLL
    {
        IUserDAL userDal;

        public User(IUserDAL userDal)
        {
            this.userDal = userDal;
        }

        public int ThirdPartyLogin(string username)
        {
            return userDal.ThirdPartyLogin(username);
        }

        public int ValidateLogin(string username, string pwd) 
        {
            return userDal.ValidateLogin(username, pwd);
        }
    }
}
