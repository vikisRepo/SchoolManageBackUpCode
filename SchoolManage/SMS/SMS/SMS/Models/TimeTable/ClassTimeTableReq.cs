using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.TimeTable
{
    public class ClassTimeTableReq
    {
        public string Class { get; set; }
        public string Section { get; set; }
        public DateTime Year { get; set; }
    }
}
