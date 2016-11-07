using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class LearningArea
    {
        List<Subject> subjects = new List<Subject>();
       
        public string LearningAreaCode { get; set; }
       
        public string Description { get; set; }
       
        public Nullable<double> Units { get; set; }
  
        public Nullable<bool> Academic { get; set; }
     
        public Nullable<double> RatePerUnit { get; set; }
     
        public Nullable<double> RatePerSubject { get; set; }
      
        public List<Subject> Subjects
        {
            get { return subjects; }
            set { this.subjects = value; }
        }
    }

}
