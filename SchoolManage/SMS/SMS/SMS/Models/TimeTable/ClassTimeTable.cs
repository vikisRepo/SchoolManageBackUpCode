using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SMS.Models.TimeTable
{
    public class ClassTimeTable
    {
        [JsonIgnore]
        public int ClassTimeTableId { get; set; }
		public string Class { get; set; }
        public string Section { get; set; }
        public DateTime Year { get; set; }
        public List<PeriodDetail> PeriodDetails { get; set; }

    }
}
