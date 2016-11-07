using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class ScholarshipDiscount
    {
         
        public int ScholarshipDiscountId { get; set; }

        public Nullable<double> Discount { get; set; }
         
        public bool Deactivated { get; set; }

         
        public string Scholarship { get; set; }
         
        public string Description { get; set; }
    }
}
