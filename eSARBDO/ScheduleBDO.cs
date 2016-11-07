using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class ScheduleBDO
    {
        public int Schedule1 { get; set; }
        public Nullable<int> StudentAssignmentID { get; set; }
        public string TimeslotCode { get; set; }

        public SubjectAssignmentBDO SubjectAssignment { get; set; }
        public  TimeslotBDO Timeslot { get; set; }
    }
}
