using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class ScholarshipDiscountBDO
    {
        List<StudentBDO> scholars = new List<StudentBDO>();
        public int ScholarshipDiscountId { get; set; }
        public Nullable<float> Discount { get; set; }
        public bool Deactivated { get; set; }
        public string Scholarship { get; set; }
        public string Description { get; set; }
        public List<StudentBDO> ScholarList {
            get { return this.scholars; }
            set { this.scholars = value; }
        }
    }
}
