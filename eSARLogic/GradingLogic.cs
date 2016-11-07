using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class GradingLogic
    {
        GradingDAO gradeDAO = new GradingDAO();
        public List<StudentSubjectBDO> GetClassList(string SubjectAssignments)
        {
            return gradeDAO.GetClassList(SubjectAssignments);
        }
        public List<StudentTraitBDO> GetAdviseesList(int GradeSectionCode)
        {
            return gradeDAO.GetAdviseesList(GradeSectionCode);
        }

        public List<StudentSubjectBDO> GetStudentEvaluation(string StudentId)
        {
            return gradeDAO.GetStudentEvaluation(StudentId);
        }

        public List<StudentSubjectBDO> GetClassGradeReport(string SubjectAssignments)
        {
            List<StudentSubjectBDO> classGrade = new List<StudentSubjectBDO>();
            classGrade.AddRange(gradeDAO.GetClassGradeReport(SubjectAssignments, "M"));
            classGrade.AddRange(gradeDAO.GetClassGradeReport(SubjectAssignments, "F"));
            return classGrade;
        }

        public List<StudentSubjectBDO> GetStudentGradeReport(string StudentId, string sy)
        {

            return gradeDAO.GetStudentGradeReport(StudentId, sy);
        }

        public List<SubjectAssignmentBDO> GetTeacherLoading(string TeacherId, string sy)
        {
            SubjectAssignmentDAO sad = new SubjectAssignmentDAO();
            return sad.GetTeacherLoad(TeacherId, sy);
        }

        public bool SaveClassGrades(List<StudentSubjectBDO> grades)
        {
            StudentSubjectDAO ssdao = new StudentSubjectDAO();
            return ssdao.SaveClassGrades(grades);
        }

        public bool SaveTraitsGrades(List<StudentTraitBDO> grades)
        {
            StudentTraitDAO stdao = new StudentTraitDAO();
            return stdao.SaveTraitsGrades(grades);
        }
    }
}
