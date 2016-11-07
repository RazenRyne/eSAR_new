using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IGradeSectionService
    {
       
        List<GradeSection> GetAllGradeSections();
      
        List<GradeSection> GetAllSectionsForGrade(string gradeLevel);
       
        Boolean CreateGradeSection(ref GradeSection gs, ref string message);
       
        Boolean UpdateGradeSection(ref GradeSection gs, ref string message);
    
        List<Room> GetAllRooms();
      
        List<Teacher> GetAllTeachers();
        
        List<SchoolYear> GetAllSchoolYears();
        
        List<GradeLevel> GetAllGradeLevels();
        
        Teacher GetTeacher(string lastname, string middlename, string firstname);
        
        Teacher GetTeacherDetail(string teacherID, ref string message);

    }
}
