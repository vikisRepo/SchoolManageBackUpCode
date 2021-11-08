using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Transport
{
  public class BusTripReqandResp
  {
    public int BusTripid { get; set; }

    public string TripNumber { get; set; }

    public string TripAreas { get; set; }

    public string TripTimingFrom { get; set; }

    public string TripTimingTo { get; set; }

    public int TotalHeadCount { get; set; }

    public int BusesAndDriverId { get; set; }


  }
}

