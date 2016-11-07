using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class Subject
    {
      
        public int SubjectID { get; set; }
      
        public string SubjectCode { get; set; }
      
        public string LearningAreaCode { get; set; }
      
        public string GradeLevel { get; set; }
      
        public string Description { get; set; }
      
        public LearningArea LArea { get; set; }
      
        public bool Academic { get; set; }
      
        public Nullable<int> MPW { get; set; }
    }
}
