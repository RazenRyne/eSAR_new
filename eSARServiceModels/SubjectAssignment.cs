using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class SubjectAssignment
    {
         
        public string SY { get; set; }
         
        public string SubjectCode { get; set; }
         
        public string SubjectDescription { get; set; }
         
        public string TimeSlotCode { get; set; }
         
        public int RoomId { get; set; }
         
        public string TeacherId { get; set; }
         
        public int GradeSectionCode { get; set; }
         
        public int Class { get; set; }
         
        public bool Deactivated { get; set; }
         
        public int SubjectAssignmentsID { get; set; }
         
        public string SubjectAssignments { get; set; }
         
        public GradeSection GradeSection { get; set; }
         
        public string GradeLevel { get; set; }
         
        public string Section { get; set; }
         
        public Room Room { get; set; }
         
        public string RoomCode { get; set; }
         
        public Subject Subject { get; set; }
         
        public Teacher Teacher { get; set; }
         
        public string TeacherName { get; set; }
         
        public Timeslot Timeslot { get; set; }
         
        public string Timestart { get; set; }
         
        public string TimeEnd { get; set; }
         
        public string Days { get; set; }
         
        public string TimeslotInfo { get; set; }
         
        public string SubjectInfo { get; set; }
         
        public bool Selected { get; set; }
    }
}
