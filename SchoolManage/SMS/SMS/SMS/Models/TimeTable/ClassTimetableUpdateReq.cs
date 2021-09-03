using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.TimeTable
{
	public class PeriodDetailsReq
    {
            public string Class { get; set; }
            public string Section { get; set; }
            public DateTime Year { get; set; }
            public int StaffId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public int SubjectID { get; set; }
            public int Period { get; set; }
            public string Day { get; set; }
    }
}
