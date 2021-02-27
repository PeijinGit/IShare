using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ResResult<T>
    {
        public int Status { get; set; }
        public List<T> ResultData { get; set; }
        public string Msg { get; set; }
    }
}
