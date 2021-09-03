using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class StaffType
	{
		//public StaffType()
		//{
		//	staff = new HashSet<Staff>();
		//}

		public int StaffTypeId { get; set; }

		public String Description { get; set; }

		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Staff> staff { get; set; }
	}
}
