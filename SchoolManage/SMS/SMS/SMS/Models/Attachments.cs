using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models
{
	public class Attachments
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public byte[] Attachment { get; set; }
	}
}
