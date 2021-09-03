using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class EmployeementStatus
	{
		//public EmployeementStatus()
		//{
		//	staff = new HashSet<Staff>();
		//}

		public int EmployeementStatusId { get; set; }

		public String Description { get; set; }

		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Staff> staff { get; set; }
	}
}
