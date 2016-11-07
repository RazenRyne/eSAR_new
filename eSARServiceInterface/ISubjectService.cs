using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ISubjectService
    {
         
        List<Subject> GetAllSubjects();
         
        List<Subject> GetAllSubjectsOfLearningArea(string learningAreaCode);
         
        List<Subject> GetAllSubjectsOfGradeLevel(string gradeLevel);
         
        Subject GetSubject(string subjectCode);

    }
}
