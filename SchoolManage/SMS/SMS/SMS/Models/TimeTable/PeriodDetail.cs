using SMS.Models.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.TimeTable
{
    public class PeriodDetail
    {
        [JsonIgnore]
        public int PeriodDetailId { get; set; }

        //[ForeignKey("StaffId")]

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

        [JsonIgnore]
        public int ClassTimeTableId { get; set; }
        public ClassTimeTable ClassTimeTable { get; set; }
    }
}
