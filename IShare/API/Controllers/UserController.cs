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
        public Models.User ValidateLogin(Models.User user) 
        {        
            int userId = userBLL.ValidateLogin(user.Username, user.Password);
            return UserIdCheck(userId);
        }

        [HttpPost]
        public Models.User ThirdPartyLogin(Models.User user) 
        {
            int userId = userBLL.ThirdPartyLogin(user.Username);
            return UserIdCheck(userId);
        }

        /// <summary>
        /// Validate user id then return user entity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private Models.User UserIdCheck(int userId) 
        {
            if (userId == -1)
            {
                HttpContext.Response.StatusCode = 401;
                return null;
            }
            else
            {
                HttpContext.Response.StatusCode = 200;
                return new Models.User { Id = userId, LastLoginTime = DateTime.Now };
            }
        }
    }
}