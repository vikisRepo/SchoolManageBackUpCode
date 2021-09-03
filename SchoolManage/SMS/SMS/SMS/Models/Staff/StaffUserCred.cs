using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class StaffUserCred 
	{
		public StaffUserCred()
		{
			Staff = new HashSet<Staff>();
		}

		[JsonIgnore]
		[Key]
		public int StaffId { get; set; }

		public string Username { get; set; }
		public string Password { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public virtual ICollection<Staff> Staff { get; set; }
	}
}
