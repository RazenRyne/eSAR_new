using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ISubjectAssignmentService
    {
         
        List<GradeLevel> GetAllGradeLevels();
         
        List<GradeSection> GetAllSections();
         
        List<GradeSection> GetAllSectionsOfGradeLevel(string gradeLevel);
         
        List<Subject> GetAllSubjects();
         
        List<SubjectAssignment> GetAllSchedulesbySection(int iGradeSection, string sy);
         
        List<Subject> GetAllSubjectsOfGradeLevel(string gradeLevel);
         
        List<Timeslot> GetTimeslots();
         
        List<Room> GetAllRooms();
         
        List<Teacher> GetAllTeachers();
         
        List<Room> GetAvailableRooms(string timeslotcode);
         
        List<Teacher> GetAvailableTeachers(string timeslotcode);
         
        List<SubjectAssignment> GetAllSchedules();
         
        List<SubjectAssignment> GetTeacherSchedule(string teacherId, string sy);
         
        List<SubjectAssignment> GetRoomSchedule(int roomCode);
         
        List<StudentSchedule> GetStudentSchedule(int gradeSectionCode, string sy);

         
        List<SubjectAssignment> GetStudentExSchedule(int gradeSectionCOde, string sy);

         
        Boolean CreateSchedule(List<SubjectAssignment> schedule);
         
        Boolean UpdateSchedule(List<SubjectAssignment> schedule);

         
        string GetCurrentSY();


         
        Boolean CreateSchedules(SubjectAssignment subjectAssignment, string message);

         
        Boolean DeleteSchedule(int schedId, ref string message);
         
        List<SubjectAssignment> GetRightSchedule(int Rank, string GradeLevel);
         
        SubjectAssignment GetScheduleInfo(int SubjecAssignmentsId);
         
        List<SchoolYear> GetAllSY();
    }
}
