using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Course
{
	public class CourseContent
	{
		public int CourseContentId { get; set; }

		[ForeignKey("ContentTypeId")]
		public int ContentTypeId { get; set; }
		public ContentType ContentType { get; set; }

		[ForeignKey("CourseDetailId")]
		public int CourseDetailId { get; set; }
		public CourseDetail CourseDetail { get; set; }

		public string PathToFile { get; set; }
	}

	public class ContentType
	{
		public int ContentTypeId { get; set; }

		public string Description { get; set; }
	}
}
