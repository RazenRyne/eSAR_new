using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class WorkExperienceBDO
    {
        public string TeacherId { get; set; }
        public int WEId { get; set; }
        public Nullable<DateTime> WorkExpFrom { get; set; }
        public Nullable<DateTime> WorkExpTo { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public Nullable<double> MonthlySalary { get; set; }
        public string StatusOfEmployment { get; set; }
    }
}
