using System;
using System.Collections.Generic;
using System.Text;

namespace IShare.Model
{
    [Serializable]
    public class Events
    {
        public System.Int32 Id
        {
            set;
            get;
        }

        public System.String EventName
        {
            set;
            get;
        }
    }
}
