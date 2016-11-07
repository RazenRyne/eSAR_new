using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class LearningAreaBDO
    {
        List<SubjectBDO> subjects = new List<SubjectBDO>();
        public string LearningAreaCode { get; set; }
        public string Description { get; set; }
        public Nullable<double> Units { get; set; }
        public Nullable<bool> Academic { get; set; }
        public Nullable<double> RatePerUnit { get; set; }
        public Nullable<double> RatePerSubject { get; set; }

    public List<SubjectBDO> Subjects {
            get { return subjects; }
            set { this.subjects = value; }
        }
    }
}
