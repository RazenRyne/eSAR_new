using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class TeacherEducationalBackgroundBDO
    {
            public string TeacherId { get; set; }
            public int TEBId { get; set; }
            public string EducLevel { get; set; }
            public string NameOfSchool { get; set; }
            public DateTime TEBYearFrom { get; set; }
            public DateTime TEBYearTo { get; set; }
            public string Course { get; set; }
            public string HonorsReceived { get; set; }
            public bool Deactivated { get; set; }
        }
}
