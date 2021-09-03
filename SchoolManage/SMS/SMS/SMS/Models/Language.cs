using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class Language
	{
		//public Languages()
		//{
		//	staff = new HashSet<Staff>();
		//}

		public int LanguageId { get; set; }

		public string LanguageDescription { get; set; }

		//[JsonIgnore]
		//[IgnoreDataMember]
		//public virtual ICollection<Staff> staff { get; set; }
	}
}
