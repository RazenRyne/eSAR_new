using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IRegistrationService
    {
         
        List<GradeLevel> GetAllGradeLevel();
         
        List<SchoolYear> GetAllSY();
         
        SchoolYear GetCurrentSY();
         
        Student StudentInfoWithRank(string IDnum, string gradeLevel, string gender);
         
        Boolean EnrolStudent(StudentEnrollment studentEnr);
         
        Boolean EnrolIrregStudent(StudentEnrollment studentEnr);
         
        List<string> GetEnrolledStudents(string sy);
         
        List<StudentEnrollment> GetCurrentStudents(string sy);
         
        StudentEnrollment GetStudentEnrolled(string IDNum, string SY);
         
        Boolean CreateStudentAssessment(StudentAssessment studAss);

        List<StudentAssessment> AssessMe(StudentEnrollment student);
         
        List<StudentAssessment> GetStudentAssessment(string IDNum, string SY);
         
        List<Fee> GetStudentFees(StudentEnrollment student);
         
        List<ScholarshipDiscount> GetScholarshipDiscounts();
         
        List<StudentSubject> GetFailedSubjects(string IDSy);
         
        List<StudentSchedule> GetSubjectSchedules(string sy);
         
        Boolean ControlSubjects(string StudentId, string sy, List<StudentSubject> subs);
         
        Boolean DeleteLoadedSubjects(string StudentId, string sy, List<StudentSubject> subs);
        // 
        //void ControlStudent(StudentEnrollment student);
         
        List<StudentSubject> GetStudentSubjects(string studentIdSy);
         
        Student GetStudent(string StudentId, ref string message);
         
        List<SubjectAssignment> GetStudentSchedule(int rank, string gradelevel);
         
        List<StudentSchedule> GetStudentExistingSchedule(List<StudentSubject> StudentSubjectList, string sy);
         
        bool UpdateStudent(ref Student student, ref string message);
         
        List<StudentSchedule> GetSubjectsOfSection(int GradeSectionCode, string sy);
         
        List<GradeSection> GetAllGradeSection(string gradeLevel);

        List<string> GetEnrolledStudentsforNewTraits(string gradelevel, string sy);

        Boolean UpdateStudentCharacters(Trait tbdo);

        Boolean DeleteExistingSubjects(String studentSy);

        Boolean UpdateStudentSection(String studentSy, int gradeSectionCode, string section);

        bool UpdateStudentBalance(string studentSy, string studentID, float assessmentfee);
    }
}
