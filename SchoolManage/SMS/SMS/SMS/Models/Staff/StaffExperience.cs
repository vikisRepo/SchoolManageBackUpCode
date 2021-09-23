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
        public int StaffExperienceId { get; set; }
        public DateTime? From { get; set; }

		public DateTime? To { get; set; }

		public string Responsibilty { get; set; }

	}
}
