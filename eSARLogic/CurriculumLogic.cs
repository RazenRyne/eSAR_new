using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;
namespace eSARLogic
{
    public class CurriculumLogic
    {
        CurriculumDAO cdao = new CurriculumDAO();
        public List<CurriculumBDO> GetAllCurriculums()
        {
            return cdao.GetAllCurriculums();
        }

        public Boolean CreateCurriculum(ref CurriculumBDO cbdo, ref string message)
        {
            return cdao.CreateCurriculum(ref cbdo, ref message);
        }

        public Boolean UpdateCurriculum(ref CurriculumBDO cbdo, ref string message)
        {
            return cdao.UpdateCurriculum(ref cbdo, ref message);
        }

        public List<CurriculumSubjectBDO> GetAllCurriculumSubjects(string currCode)
        {
            return cdao.GetCurriculumSubjects(currCode);
        }

    }
}
