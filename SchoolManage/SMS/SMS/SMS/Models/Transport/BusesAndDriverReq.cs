using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Models.Transport
{
    public class BusesAndDriverReq
    {
        public int busTypeid { get; set; }

        public int seatCount { get; set; }

        public string busNumber { get; set; }

        public string insurancePolicyNum { get; set; }

        public DateTime insuranceEndDate { get; set; }

        public int notificationSpanId { get; set; }

        //public string busStatus { get; set; }

        //public DateTime arrivalTime { get; set; }

        public string driverName { get; set; }

        public int driverNumber { get; set; }

        public string driverAadhar { get; set; }

        //public byte busLocation { get; set; }

        public string company { get; set; }
    }
}
