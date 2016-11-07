using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class TrainingSeminarBDO
    {
        public string TeacherId { get; set; }
        public int TSID { get; set; }
        public string Title { get; set; }
        public string AreaOfTraining { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double NoOfHours { get; set; }
        public string ConductedBy { get; set; }
    }
}
