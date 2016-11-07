using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class StudentAssessmentBDO
    {
        public int StudentAssessmentId { get; set; }
        public string StudentSY { get; set; }
        public Nullable<int> FeeID { get; set; }
        public int DiscountId { get; set; }

        public  FeeBDO Fee { get; set; }
        public  StudentEnrollmentBDO StudentEnrollment { get; set; }
        public  ScholarshipDiscountBDO ScholarshipDiscount { get; set; }
    }
}
