using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class Fee
    {
       
        public int FeeID { get; set; }
       
        public int NumPay { get; set; }
       
        public float DiscountFullPay { get; set; }
       
        public string FeeDescription { get; set; }
       
        public bool Deactivated { get; set; }
       
        public Nullable<double> Amount { get; set; }
       
        public string SYImplemented { get; set; }
       
        public string GradeLevel { get; set; }
       
        public string GradeLev { get; set; }
    }
}
