using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Message
{
  public class MessageRecipient
  {
    public int MessageRecipientId { get; set; }

    public int IsRead { get; set; }

    public ICollection<Message> Messages { get; set; }

  }
}
