using SMS.Models.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Message
{
  public class Message
  {
    public int MessageId { get; set; }

    public string  Subject { get; set; }

    public string MessageBody { get; set; }

    public int CreatedDate { get; set; }

    public int ParentMessageId { get; set; }

    public DateTime Expirydate { get; set; }

    public int IsReminder { get; set; }

    public DateTime NextReminderDate { get; set; }

    [ForeignKey("ParentMessageId")]
    public Message ParentMessage { get; set; }

  }
}
