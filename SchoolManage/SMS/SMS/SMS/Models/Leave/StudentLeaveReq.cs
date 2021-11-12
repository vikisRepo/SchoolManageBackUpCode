using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.Leave
{
	public class StudentLeaveReq
	{
		public int LeaveSessionID { get; set; }

		public int LeaveTypeID { get; set; }

		public int admissionNo { get; set; }

		public int noOfDays { get; set; }

		public DateTime datefrom { get; set; }

		public DateTime dateto { get; set; }

		public string Reason { get; set; }

		public string status { get; set; }

		public string approver { get; set; }

		public byte attachment { get; set; }
	}
}
