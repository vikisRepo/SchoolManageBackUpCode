using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.Leave
{
	public class StaffLeave
	{
		public int StaffLeaveId { get; set; }

		[ForeignKey("LeaveSessionID")]
        public int LeaveSessionID { get; set; }
        public LeaveSession LeaveSession { get; set; }

		[ForeignKey("LeaveTypeID")]
        public int LeaveTypeID { get; set; }
        public LeaveType LeaveType { get; set; }

        public int employeeID { get; set; }

        public int noOfDays { get; set; }

		public DateTime datefrom { get; set; }

		public DateTime dateto { get; set; }

		public string Reason { get; set; }

        public string status { get; set; }

        public string approver { get; set; }

        public byte attachment { get; set; }
	}
}
