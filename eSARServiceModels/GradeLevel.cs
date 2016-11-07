using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class GradeLevel
    {
        List<Trait> traits = new List<Trait>();
        List<Fee> studFees = new List<Fee>();

        public string GradeLev { get; set; }

        public string Description { get; set; }

        public Nullable<int> Category { get; set; }

        public List<Fee> StudentFees
        {
            get { return studFees; }
            set { studFees = value; }
        }

        public List<Trait> Traits
        {
            get { return this.traits; }
            set { this.traits = value; }
        }
    }
}
