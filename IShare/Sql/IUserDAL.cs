using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserDAL
    {
         int ValidateLogin(string username, string pwd);
       
    }
}
