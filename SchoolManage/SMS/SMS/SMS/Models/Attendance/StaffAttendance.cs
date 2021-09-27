using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Attendance
{
	public class StaffAttendance
	{
		public int StaffAttendanceId { get; set; }

		public DateTime AttendanceDate { get; set; }
		public string StaffName { get; set; }
		public string EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int StaffTypeId { get; set; }
        public int Present { get; set; }
		public int Absent { get; set; }
		public int HalfDay { get; set; }
        public int RowInactive { get; set; }
    }
}
