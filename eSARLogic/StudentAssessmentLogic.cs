using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class StudentAssessmentLogic
    {
        StudentAssessmentDAO sadao = new StudentAssessmentDAO();
        public void AssessStudent(StudentAssessmentBDO sabdo) {
            sadao.CreateStudentAssessment(sabdo);

        }

        public List<StudentAssessmentBDO> GetStudentAssessment(string id, string sy) {
            return sadao.GetStudentAssessment(id, sy);

        }
    }
}
