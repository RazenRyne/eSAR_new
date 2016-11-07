using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class FeeBDO
    {
        public int FeeID { get; set; }
        public Nullable<int> NumPay { get; set; }
        public string FeeDescription { get; set; }
        public bool Deactivated { get; set; }
        public Nullable<double> Amount { get; set; }
        public string SYImplemented { get; set; }
        public string GradeLevel { get; set; }
        public Nullable<double> DiscountFullPay { get; set; }
    }
}
