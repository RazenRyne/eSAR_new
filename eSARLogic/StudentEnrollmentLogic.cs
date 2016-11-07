using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class StudentEnrollmentLogic
    {
        StudentEnrolmentDAO enrolDAO = new StudentEnrolmentDAO();
        StudentSubjectDAO controlDAO = new StudentSubjectDAO();

        public Boolean RegisterStudent(StudentEnrollmentBDO student, ref string message)
        {
            return enrolDAO.EnrolStudent(student, ref message);
        } 

        public List<string> GetEnrolledIds(string sy) {
           return enrolDAO.GetEnrolledIds(sy);
        }

        public List<string> GetEnrolledIdsNewTraits(string gradelevel,string sy)
        {
            return enrolDAO.GetEnrolledIdsforNewTraits(gradelevel,sy);
        }

        public List<StudentEnrollmentBDO> GetEnrolledStudents(string sy) {
            return enrolDAO.GetAllEnrollmentsForSy(sy);
        }
        public StudentEnrollmentBDO GetStudentEnrolled(string IDnum, string sy) {
            return enrolDAO.GetStudentEnrolment(IDnum, sy);
        }

        public List<StudentEnrollmentBDO> GerStudentsEnrolled(string sy) {
            return enrolDAO.GetAllEnrollmentsForSy(sy);

        }

       
    }
}
