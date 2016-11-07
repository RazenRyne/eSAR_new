using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class StudentAssessment
    {
         
        public int StudentAssessmentId { get; set; }
         
        public string StudentSY { get; set; }
         
        public int FeeID { get; set; }
         
        public double Amount { get; set; }
         
        public int ScholarshipDiscountId { get; set; }
         
        public float Discount { get; set; }
    }
}
