using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class CurriculumSubjectBDO
    {
      
        public string CurrSubCode { get; set; }
        public string SubjectCode { get; set; }
        public string CurriculumCode { get; set; }
        public bool Deactivated { get; set; }
        public int CurriculumSubjectsID { get; set; }

        public SubjectBDO Sub { get; set; }
    }
}
