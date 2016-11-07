using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class Curriculum
    {
        List<CurriculumSubject> subjects = new List<CurriculumSubject>();
      
        public string CurriculumCode { get; set; }
     
        public string Description { get; set; }
     
        public bool CurrentCurr { get; set; }
     
        public List<CurriculumSubject> CurriculumSubjects
        {
            get { return subjects; }
            set { this.subjects = value; }
        }
    }
}
