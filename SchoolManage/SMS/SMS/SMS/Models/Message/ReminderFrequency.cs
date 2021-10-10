using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Message
{
  public class ReminderFrequency
  {
    public int ReminderFrequencyId { get; set; }

    public string Title { get; set; }

    public int Frequency { get; set; }

    public char IsActive { get; set; }

    public ICollection<Message> Messages { get; set; }
  }
}
