using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
   public class StudentTraitBDO
    {
        public string StudentEnrTraitCode { get; set; }
        public int TraitsID { get; set; }
        public string StudentSY { get; set; }
        public Nullable<double> FirstPeriodicRating { get; set; }
        public Nullable<double> SecondPeriodicRating { get; set; }
        public Nullable<double> ThirdPeriodicRating { get; set; }
        public Nullable<double> FourthPeriodicRating { get; set; }
        public Nullable<bool> LockFirst { get; set; }
        public Nullable<bool> LockSecond { get; set; }
        public Nullable<bool> LockThird { get; set; }
        public Nullable<bool> LockCFourth { get; set; }
        public Nullable<System.DateTime> FirstEntered { get; set; }
        public Nullable<System.DateTime> FirstLocked { get; set; }
        public Nullable<System.DateTime> SecondLocked { get; set; }
        public Nullable<System.DateTime> SecondEntered { get; set; }
        public Nullable<System.DateTime> ThirdEntered { get; set; }
        public Nullable<System.DateTime> ThirdLocked { get; set; }
        public Nullable<System.DateTime> FourthLocked { get; set; }
        public Nullable<System.DateTime> FourthEntered { get; set; }
        public Nullable<int> GradeSectionCode { get; set; }

        public virtual StudentEnrollmentBDO StudentEnrollment { get; set; }
        public virtual TraitBDO Trait { get; set; }
        public virtual GradeSectionBDO GradeSection { get; set; }
    }
}
