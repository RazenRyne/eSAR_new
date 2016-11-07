using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class StudentSubjectBDO
    {
        public string StudentEnrSubCode { get; set; }
        public string StudentSY { get; set; }
        public string SubjectCode { get; set; }
        public Nullable<double> FirstPeriodicRating { get; set; }
        public Nullable<double> SecondPeriodicRating { get; set; }
        public Nullable<double> ThirdPeriodicRating { get; set; }
        public Nullable<double> FourthPeriodicRating { get; set; }
        public string Remarks { get; set; }
        public int StudentSubjectsID { get; set; }
        public Nullable<bool> LockFirst { get; set; }
        public Nullable<bool> LockSecond { get; set; }
        public Nullable<bool> LockThird { get; set; }
        public Nullable<bool> LockFourth { get; set; }
        public int SubjectAssignmentID { get; set; }
        public Nullable<System.DateTime> FirstEntered { get; set; }
        public Nullable<System.DateTime> SecondEntered { get; set; }
        public Nullable<System.DateTime> ThirdEntered { get; set; }
        public Nullable<System.DateTime> FourthEntered { get; set; }
        public Nullable<System.DateTime> FourthLocked { get; set; }
        public Nullable<System.DateTime> ThirdLocked { get; set; }
        public Nullable<System.DateTime> SecondLocked { get; set; }
        public Nullable<System.DateTime> FirstLocked { get; set; }
        public string SubjectAssignments { get; set; }

        public StudentEnrollmentBDO StudentEnrollment { get; set; }
        public  SubjectBDO Subject { get; set; }
      
    }
}
