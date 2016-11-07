using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;
namespace eSARLogic
{
    public class StudentSubjectLogic
    {
        StudentSubjectDAO ssd = new StudentSubjectDAO();
        public Boolean ControlStudent(StudentSubjectBDO ssb, ref string message) {
            return ssd.CreateStudentSubject(ssb, ref message);
        }

        public List<StudentSubjectBDO> GetFailedSubjects(string IdSy) {
            return ssd.GetFailedSubjects(IdSy);
        }

        public List<StudentSubjectBDO> GetStudentSubjects(string studidsy) {
            return ssd.GetStudentSubjects(studidsy);
        }

        public Boolean DeleteStudentLoad(StudentSubjectBDO ssb, ref string message) {
            return ssd.DeleteStudentSubject(ssb, ref message);
        }

        public Boolean DeleteExistingSubjects(string studentsy) {
            return ssd.DeleteExistingSubjects(studentsy);
        }

        public Boolean UpdateStudentSection(string studentsy, int gradeSectionCode) {
            return ssd.UpdateStudentSection(studentsy, gradeSectionCode);
        }
    }
}
