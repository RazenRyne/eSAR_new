using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IGradingService
    {
         
        List<StudentSubject> GetClassList(string SubjectAssignments);
         
        Teacher GetTeacher(string lastname, string middlename, string firstname);
         
        List<TeacherLoad> GetTeacherLoad(string TeacherId, string sy);
         
        List<TeacherLoad> GetAllTeachersLoad(string sy);
         
        void LockGrades(int Grading, List<StudentSubject> grades);
         
        List<StudentSubject> GetClassGrades(string SubjectAssignments);
         
        bool SaveClassGrades(List<StudentSubject> grades);
         
        List<StudentSubject> GetStudentGrades(string StudentId, string sy);
         
        List<StudentSubject> GetStudentEvaluation(string StudentId);
         
        List<StudentTrait> GetAdvisees(int GradesectionCode);
         
        List<StudentTrait> GetStudentTrait(string StudentId, string sy);
         
        bool SaveTraitsGrade(List<StudentTrait> grades);
         
        void LockTraitsGrade(int Grading, List<StudentTrait> grades);
         
        Teacher GetTeacherDet(string teacherId, ref string message);
    }
}
