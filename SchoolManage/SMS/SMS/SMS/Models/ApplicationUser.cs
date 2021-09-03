using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class ApplicationUser : IdentityUser
	{
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[JsonIgnore]
		[IgnoreDataMember]
		public int StaffId { get; set; }

		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[JsonIgnore]
		[IgnoreDataMember]
		public int StudentId { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public virtual Staff Staff { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public virtual ICollection<Student> Student { get; set; }
	}
}
