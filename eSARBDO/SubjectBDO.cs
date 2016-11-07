using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class SubjectBDO
    {
        public int SubjectID { get; set; }
        public string SubjectCode { get; set; }
        public string LearningAreaCode { get; set; }
        public string GradeLevel { get; set; }
        public string Description { get; set; }
        public Nullable<int> MPW { get; set; }

        public LearningAreaBDO LearningArea { get; set; }

        public bool Academic { get; set; }
        //   public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        //     public virtual ICollection<SubjectAssignment> SubjectAssignments { get; set; }
    }
}
