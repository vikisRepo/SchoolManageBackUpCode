using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Attendance
{
    public class StudentAttendance
    {
        public int StudentAttendanceId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string StudentName { get; set; }
        public int AdmissionNumber { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }
        public int HalfDay { get; set; }
        public int RowInactive { get; set; }
    }
}
