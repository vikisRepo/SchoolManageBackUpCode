using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public partial class StaffFeedback
	{
		[JsonIgnore]
		public int StaffFeedbackID { get; set; }
		public string Empid { get; set; }
		public string  StaffName { get; set; }

		public string FeedbackType { get; set; }

		public DateTime Date { get; set; }

		public string Department { get; set; }

		public string TeacherId { get; set; }

		public string Description { get; set; }

    public string Feedbacktitle { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public int AttachmentId { get; set; }

    public DateTime DateCreated { get; set; }
  }
}
