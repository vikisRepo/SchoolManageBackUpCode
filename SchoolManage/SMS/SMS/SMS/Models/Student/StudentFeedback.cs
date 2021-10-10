using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class StudentFeedback
	{
    [JsonIgnore]
    [IgnoreDataMember]
    public int StudentFeedbackId { get; set; }

		public int StaffId { get; set; }

		public string FeedbackType { get; set; }

		public DateTime Date { get; set; }

		public string Class { get; set; }

		public string Feedbacktitle { get; set; }

		public string Section { get; set; }

		public string Description { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public int AttachmentId { get; set; }

		public int AdmissionNumber { get; set; }

    public DateTime DateCreated { get; set; }

  }

	public class StudentFeedbackReq
	{

		public string StaffName { get; set; }

		public string FeedbackType { get; set; }

		public DateTime Date { get; set; }

		public string Class { get; set; }

		public string Feedbacktitle { get; set; }

		public string Section { get; set; }

		public string TeacherId { get; set; }

		public string Description { get; set; }

		public string Attachment { get; set; }

	}
}

