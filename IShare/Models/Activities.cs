using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Activities
    {
        public string Id { get; set; }
        public string AcName { get; set; }
        public int EsFee { get; set; }
        public string Descript { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventId { get; set; }
        public byte AcStatus { get; set; }
        public string Img { get; set; }
        public string Detail { get; set; }
        public byte Vision { get; set; }
    }
}
