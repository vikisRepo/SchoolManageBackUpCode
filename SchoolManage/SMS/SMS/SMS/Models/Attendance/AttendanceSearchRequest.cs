using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Attendance
{
	enum AttendanceTypes
	{
		Present =1,
		Absent = 2,
		HalfDay =3
	}
	public class StaffAttendanceSearchRequest
	{
		//{ "department": 2, "staffType": 3, "DateFor": "2021-09-27T18:30:00.000Z" }

		public int department { get; set; }
		public int staffType { get; set; }
		public DateTime DateFor { get; set; }
	}

    public class StaffAttendanceUpdateRequest
	{
		public int StaffAttendanceId { get; set; }
		public string EmployeeId { get; set; }
        public int UpdateType { get; set; }
    }

	public class StudentAttendanceSearchRequest
	{
		public string Class { get; set; }
		public string Section { get; set; }
		public DateTime DateFor { get; set; }
	}

	public class StudentAttendanceUpdateRequest
	{
		public int StudentAttendanceId { get; set; }
		public int AdmissionNumber { get; set; }
		public int UpdateType { get; set; }
	}
}
