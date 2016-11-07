using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class SiblingBDO
    {
        public int SiblingId { get; set; }
        public string StudentId { get; set; }
        public string SiblingStudentId { get; set; }

        public StudentBDO Student { get; set; }
        public StudentBDO Student1 { get; set; }
    }
}
