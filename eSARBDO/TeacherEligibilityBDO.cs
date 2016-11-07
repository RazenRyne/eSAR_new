using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class TeacherEligibilityBDO
    {
        public string TeacherId { get; set; }
        public int EligibilityId { get; set; }
        public string Eligibility { get; set; }
        public string Rating { get; set; }
        public DateTime DateOfExam { get; set; }
        public string PlaceOfExam { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime IssueDate { get; set; }

    }
}
