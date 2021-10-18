using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models
{
  public class StaffAttachments
  {
      [JsonIgnore]
      [IgnoreDataMember]
      public int StaffAttachmentsId { get; set; }

      public string EmployeeId { get; set; }

      public string DocumentType { get; set; }

      public string PathToFile { get; set; }
  }
}
