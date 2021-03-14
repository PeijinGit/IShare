using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AcPageResult
    {
        public int PageNum { get; set; }
        public int totalNum { get; set; }
        public int totalPages { get; set; }
        public int PageSize { get; set; }
        public List<Activities> Activities { get; set; }

    }
}
