using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.Transport
{
  public class BusTrip
  {
    public int BusTripid { get; set; }

    public string TripNumber { get; set; }

    public string TripAreas { get; set; }

    public TimeSpan TripTimingFrom { get; set; }

    public TimeSpan TripTimingTo { get; set; }

    public int TotalHeadCount { get; set; }

    [JsonIgnore]
    [ForeignKey("BusesAndDriverId")]
    public int BusesAndDriverId { get; set; }

    public BusesAndDriver BusesAndDrivers { get; set; }

    public virtual ICollection<Student> Students { get; set; }


  }
}
