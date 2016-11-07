using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class StudentEnrollmentBDO
    {
       // List<StudentAssessmentBDO> assesmenList
        public string StudentSY { get; set; }
        public string StudentId { get; set; }
        public string SY { get; set; }
        public string GradeLevel { get; set; }
        public Nullable<int> GradeSectionCode { get; set; }
        public Nullable<bool> Dismissed { get; set; }
        public int StudentEnrollmentsID { get; set; }
        public Nullable<int> DiscountId { get; set; }
        public string Stat { get; set; }
        public int Rank { get; set; }

        public GradeSectionBDO GradeSection { get; set; }
        public SchoolYearBDO SchoolYear { get; set; }
        public List<StudentAssessmentBDO> StudentAssessments { get; set; }
        public StudentBDO Student { get; set; }       
        public List<StudentTraitBDO> StudentTraits { get; set; }
       public List<StudentSubjectBDO> StudentSubjects { get; set; }
        public  ScholarshipDiscountBDO ScholarshipDiscount { get; set; }
    }
}
