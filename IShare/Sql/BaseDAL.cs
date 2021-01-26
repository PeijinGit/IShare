using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace DAL
{
    public class BaseDAL
    {
        private readonly IOptions<ConnectionStrings> _appConfiguration;
        protected string connectionString;

        public BaseDAL(IOptions<ConnectionStrings> appConfiguration) 
        {
            _appConfiguration = appConfiguration;
            connectionString = _appConfiguration.Value.ConStr;
        }

    }
}
