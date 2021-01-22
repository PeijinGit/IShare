using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        IUserBLL userBLL;

        public UserController(IUserBLL userBLL)
        {
            this.userBLL = userBLL;
        }

        [HttpPost]
        public int ValidateLogin(string username, string password) 
        {
           
            int userId = userBLL.ValidateLogin(username, password);

            if (userId == -1) 
            {
                HttpContext.Response.StatusCode = 401;
                return -1;
            }
            else 
            {
                HttpContext.Response.StatusCode = 200;
                return userId;
            }
        }
    }
}