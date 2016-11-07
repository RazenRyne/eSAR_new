using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class SchoolYearBDO
    {
        //List<StudentEnrollmentBDO> studentsEnrolled = new List<StudentEnrolledBDO>();
        List<FeeBDO> fees = new List<FeeBDO>();
        public string SY { get; set; }
        public bool CurrentSY { get; set; }
        //public List<StudentEnrolledBDO> StudentEnrollments{
        //    get { return this.studentsEnrolled; }
        //    set { this.studentsEnrolled = value; }
        //}
        public List<FeeBDO> Fees {
            get { return fees; }
            set { fees = value; }
        }

    }
}
