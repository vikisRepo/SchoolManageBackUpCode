using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Course
{
	public class CourseDetail
	{
		public int CourseDetailID { get; set; }
		public int Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Topic { get; set; }
		public bool Status { get; set; }

		[ForeignKey("CompletionCriteriaId")]
		public CompletionCriteria CompletionCriteria { get; set; }
		public int PassingScore { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}
