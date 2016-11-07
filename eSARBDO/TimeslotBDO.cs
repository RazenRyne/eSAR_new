using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class TimeslotBDO
    {
        public string TimeSlotCode { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Days { get; set; }
        public bool Deactivated { get; set; }
        public Nullable<int> TotalMins { get; set; }
    }
}
