using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;
namespace eSARLogic
{

    public class LearningAreaLogic
    {
        LearningAreaDAO laDao = new LearningAreaDAO();

        public bool CreateLearningArea(ref LearningAreaBDO la, ref string message)
        {
            return laDao.CreateLearningArea(ref la, ref message);
        }

        public List<LearningAreaBDO> GetAllLearningAreas()
        {
            List<LearningAreaBDO> labad = new List<LearningAreaBDO>();
            labad= laDao.GetLearningAreas();
            return labad;
        }

        public LearningAreaBDO GetLearningArea(string learningAreaCode)
        {
            return laDao.GetLearningArea(learningAreaCode);
        }

        public List<SubjectBDO> GetAllSubjects(string learningAreaCode)
        {
            return laDao.GetSubjectsforLearningArea(learningAreaCode);
        }

        public bool UpdateLearningArea(ref LearningAreaBDO learningArea, ref string message)
        {
            return laDao.UpdateLearningArea(ref learningArea, ref message);
        }

        public List<GradeLevelBDO> GetAllGradeLevels()
        {
            return laDao.GetAllGradeLevels();
        }
    }
}
