using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ICurriculumService
    {
        List<GradeLevel> GetAllGradeLevels();
         Boolean UpdateCurriculum(ref Curriculum curriculum, ref string message);
       
        Boolean CreateCurriculum(ref Curriculum curriculum, ref string message);
       
        List<Curriculum> GetAllCurriculums();
       
        List<CurriculumSubject> GetCurriculumSubjects(string curriculumCode);
       
        List<CurriculumSubject> GetAllSubjectDetails();
        
        List<CurriculumSubject> GetAllSubjectsOfGradeLevel(string gradeLevel);


    }
}
