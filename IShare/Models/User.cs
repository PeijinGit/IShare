using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public DateTime createTime { get; set; }
        public DateTime lastLoginTime { get; set; }
    }
}
