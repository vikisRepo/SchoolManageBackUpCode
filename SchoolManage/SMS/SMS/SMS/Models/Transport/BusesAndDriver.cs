using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Transport
{
    public class BusesAndDriver
    {
        public int BusesAndDriverId { get; set; }

        public int BusTypeid { get; set; }

        [ForeignKey("BusTypeid")]
        public BusType BusType { get; set; }

        public int SeatCount { get; set; }

        public string BusNumber { get; set; }

        public string InsurancePolicyNum { get; set; }

        public DateTime InsuranceEndDate { get; set; }

        public int NotificationSpanId { get; set; }

        [ForeignKey("NotificationSpanId")]
        public NotificationSpan NotificationSpan { get; set; }

        //public string BusStatus { get; set; }

        //public DateTime ArrivalTime { get; set; }

        public string DriverName { get; set; }

        public int DriverNumber { get; set; }

        public string DriverAadhar { get; set; }

        //public byte BusLocation { get; set; }

        public string company { get; set; }
    }
}
