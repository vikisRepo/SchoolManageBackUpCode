using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class StaffExperience
	{
		//public StaffExperience()
		//{
		//	staff = new HashSet<Staff>();
		//}

		[JsonIgnore]
		[IgnoreDataMember]
		public int StaffExperienceId { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public int StaffId { get; set; }
		public DateTime? From { get; set; }

		public DateTime? To { get; set; }

		public string Responsibilty { get; set; }


		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Staff> staff { get; set; }
	}
}
