using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
   public class SubjectLogic
    {
        SubjectDAO sdao = new SubjectDAO();
        public List<SubjectBDO> GetAllSubjects()
        {
            return sdao.GetAllSbjects();
        }

        public SubjectBDO GetSubject(string subjectCode)
        {
            return sdao.GetSubject(subjectCode);
        }

        public List<SubjectBDO> GetAllSubjectsOfGradeLevel(string gradeLevel)
        {
            return sdao.GetSubjectsforGradeLevel(gradeLevel);
        }

        public List<SubjectBDO> GetAllSubjectsOfLearningArea(string learningAreaCode)
        {
            return sdao.GetSubjectsforLearningArea(learningAreaCode);
        }
    }
}
