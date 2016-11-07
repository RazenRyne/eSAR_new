using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ILearningAreaService
    {

         
        Boolean UpdateLearningArea(ref LearningArea learningArea, ref string message);
         
        Boolean CreateLearningArea(ref LearningArea learningArea, ref string message);
         
        List<Subject> GetAllSubjects(string learningAreaCode);
         
        LearningArea GetLearningArea(string learningAreaCode);
         
        List<LearningArea> GetAllLearningAreas();
    }
}
