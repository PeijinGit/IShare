using System;

namespace IShare.Model
{
    [Serializable]
    public class Users
    {
        public System.Int32 Id 
        {
            set;
            get;
        }

        public System.String UserNo
        {
            set;
            get;
        }

        public System.String UserName
        {
            set;
            get;
        }
        public System.String PassWord
        {
            set;
            get;
        }
    }
}
