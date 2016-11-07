using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class SubjectAssignmentBDO
    {
        public string SY { get; set; }
        public string SubjectCode { get; set; }
       public int RoomId { get; set; }
        public string TeacherId { get; set; }
        public int GradeSectionCode { get; set; }
        public bool Deactivated { get; set; }
        public int SubjectAssignmentsID { get; set; }
        public string TimeSlotCode { get; set; }
        public string GradeLevel { get; set; }

        public GradeSectionBDO GradeSection { get; set; }
        public RoomBDO Room { get; set; }
        public SubjectBDO Subject { get; set; }
        public TeacherBDO Teacher { get; set; }
          public TimeslotBDO Timeslot { get; set; }
    }
}
