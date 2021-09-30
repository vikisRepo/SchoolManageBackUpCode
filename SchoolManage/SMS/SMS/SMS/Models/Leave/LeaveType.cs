using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Leave
{
	public class LeaveType
	{
		public int LeaveTypeId { get; set; }

		public string LeaveTypeDescr { get; set; }

		public int LeaveTypeFor { get; set; }
	}
}
