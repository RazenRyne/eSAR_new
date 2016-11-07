using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARDAL;
using eSARBDO;
namespace eSARLogic
{
    public class GradeLevelLogic
    {
        List<GradeLevelBDO> gList = new List<GradeLevelBDO>();
        GradeLevelDAO gdao = new GradeLevelDAO();
        public List<GradeLevelBDO> GetAllGradeLevels()
        {
            return gdao.GetAllGradeLevels();
        }
        public string GetGradeLevel(string gradeLevel)
        {
            gList = GetAllGradeLevels();
            GradeLevelBDO g = new GradeLevelBDO();
            g = gList.Find(p => p.GradeLev == gradeLevel);
            if (g != null)
                return g.Description;
            else
                return null;
        }

        public GradeLevelBDO NextGradeLevel(String grade) {
            List<GradeLevelBDO> glist = GetAllGradeLevels();
            GradeLevelBDO dbase = new GradeLevelBDO();
                dbase = glist.Find(p => p.GradeLev.Equals(grade));
            GradeLevelBDO gNext = new GradeLevelBDO();
                if (dbase.level == null)
                    dbase.level = -1;

                gNext = glist.Find(p => p.level == (dbase.level + 1));

            return gNext;
        }
    }
}
