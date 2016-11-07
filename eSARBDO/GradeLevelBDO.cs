using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class GradeLevelBDO
    {
        private List<GradeSectionBDO> gradeSections = new List<GradeSectionBDO>();
        private List<SubjectBDO> subjects = new List<SubjectBDO>();
        private List<FeeBDO> fees= new List<FeeBDO>();
        private List<TraitBDO> traits = new List<TraitBDO>();

        public string GradeLev{ get; set; }
        public string Description { get; set; }
        public Nullable<int> level { get; set; }
        public Nullable<int> Category { get; set; }

        public List<FeeBDO> StudentFees {
            get { return fees; }
            set { fees = value; }
        }
        public List<TraitBDO> TraitSet {
            get { return this.traits; }
            set { this.traits = value; }
        }
        public List<GradeSectionBDO> GradeSections {
            get { return this.gradeSections; }
            set { this.gradeSections = value; }
        }

        public List<SubjectBDO> subj {
            get { return this.subjects; }
            set { this.subjects = value; }
        }
    }
}
