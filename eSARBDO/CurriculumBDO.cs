using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class CurriculumBDO
    {
        List<CurriculumSubjectBDO> subjects = new List<CurriculumSubjectBDO>();
        public string CurriculumCode { get; set; }
        public string Description { get; set; }
        public bool CurrentCurr { get; set; }

        public List<CurriculumSubjectBDO> CurriculumSubjects
        { get { return this.subjects; }
            set { this.subjects = value; }
        }
    }
}
