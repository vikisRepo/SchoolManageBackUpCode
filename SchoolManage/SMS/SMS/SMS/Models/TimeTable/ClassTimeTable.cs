using SMS.Models.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.TimeTable
{
    public class ClassTimeTable
    {
        [JsonIgnore]
        public int ClassTimeTableId { get; set; }
		    public string Class { get; set; }
        public string Section { get; set; }
        public DateTime Year { get; set; }
        public DateTime Date { get; set; }
        public int StaffId { get; set; }

       [JsonIgnore]  
       public Staff Staffs { get; set; }

      public DateTime StartTime { get; set; }

      public DateTime EndTime { get; set; }

      //[ForeignKey("SubjectID")]

      public int SubjectID { get; set; }

    [JsonIgnore]
    public Subject Subject { get; set; }

    public int Period { get; set; }

    public string Day { get; set; }


    }
}
