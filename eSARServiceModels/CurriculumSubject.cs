using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class CurriculumSubject
    {
    
        public string CurrSubCode { get; set; }
    
        public string CurrDescription { get; set; }
    
        public Boolean CurrentCurr { get; set; }
    
        public string CurriculumCode { get; set; }
    
        public bool Deactivated { get; set; }
    
        public Subject Subj { get; set; }
    
        public string SubjectCode { get; set; }
    
        public string GradeLevel { get; set; }
    
        public string SubjectDescription { get; set; }
    
        public string LearningAreaCode { get; set; }
    
        public Nullable<bool> Academic { get; set; }
    
        public Nullable<double> RatePerUnit { get; set; }
    
        public Nullable<double> Units { get; set; }
    
        public int CurriculumSubjectsID { get; set; }

    }
}
